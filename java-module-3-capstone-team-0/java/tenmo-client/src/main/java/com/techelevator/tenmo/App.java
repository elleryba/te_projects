package com.techelevator.tenmo;

import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.List;

import com.techelevator.tenmo.models.AuthenticatedUser;
import com.techelevator.tenmo.models.Transfer;
import com.techelevator.tenmo.models.TransferCredentials;
import com.techelevator.tenmo.models.TransferDTO;
import com.techelevator.tenmo.models.User;
import com.techelevator.tenmo.models.UserCredentials;
import com.techelevator.tenmo.services.AccountsService;
import com.techelevator.tenmo.services.AuthenticationService;
import com.techelevator.tenmo.services.AuthenticationServiceException;
import com.techelevator.tenmo.services.TransferService;
import com.techelevator.tenmo.services.UserService;
import com.techelevator.view.ConsoleService;

public class App {

	AccountsService accountService = new AccountsService(API_BASE_URL);
	UserService userService = new UserService(API_BASE_URL);
	TransferService transService = new TransferService(API_BASE_URL);

	private static final String API_BASE_URL = "http://localhost:8080/";

	private static final String MENU_OPTION_EXIT = "Exit";
	private static final String LOGIN_MENU_OPTION_REGISTER = "Register";
	private static final String LOGIN_MENU_OPTION_LOGIN = "Login";
	private static final String[] LOGIN_MENU_OPTIONS = { LOGIN_MENU_OPTION_REGISTER, LOGIN_MENU_OPTION_LOGIN, MENU_OPTION_EXIT };
	private static final String MAIN_MENU_OPTION_VIEW_BALANCE = "View your current balance";
	private static final String MAIN_MENU_OPTION_SEND_BUCKS = "Send TE bucks";
	private static final String MAIN_MENU_OPTION_VIEW_PAST_TRANSFERS = "View your past transfers";
	private static final String MAIN_MENU_OPTION_REQUEST_BUCKS = "Request TE bucks";
	private static final String MAIN_MENU_OPTION_VIEW_PENDING_REQUESTS = "View your pending requests";
	private static final String MAIN_MENU_OPTION_LOGIN = "Login as different user";
	private static final String[] MAIN_MENU_OPTIONS = { MAIN_MENU_OPTION_VIEW_BALANCE, MAIN_MENU_OPTION_SEND_BUCKS, MAIN_MENU_OPTION_VIEW_PAST_TRANSFERS, MAIN_MENU_OPTION_REQUEST_BUCKS, MAIN_MENU_OPTION_VIEW_PENDING_REQUESTS, MAIN_MENU_OPTION_LOGIN, MENU_OPTION_EXIT };

	private NumberFormat formatter = NumberFormat.getCurrencyInstance();
	private AuthenticatedUser currentUser;
	private ConsoleService console;
	private AuthenticationService authenticationService;
	private User[] allUsers;
	private Transfer[] allTrans;
	private int transToId;
	private int transFromId;
	private int transAmt;

	public static void main(String[] args) throws Exception {
		App app = new App(new ConsoleService(System.in, System.out), new AuthenticationService(API_BASE_URL));
		app.run();
	}

	public App(ConsoleService console, AuthenticationService authenticationService) {
		this.console = console;
		this.authenticationService = authenticationService;
	}

	public void run() throws Exception {
		System.out.println("*********************");
		System.out.println("* Welcome to TEnmo! *");
		System.out.println("*********************");

		registerAndLogin();
		mainMenu();
	}

	private void mainMenu() throws Exception {
		while(true) {
			String choice = (String)console.getChoiceFromOptions(MAIN_MENU_OPTIONS);
			if(MAIN_MENU_OPTION_VIEW_BALANCE.equals(choice)) {
				viewCurrentBalance();
			} else if(MAIN_MENU_OPTION_VIEW_PAST_TRANSFERS.equals(choice)) {
				viewTransferHistory();
			} else if(MAIN_MENU_OPTION_VIEW_PENDING_REQUESTS.equals(choice)) {
				viewPendingRequests();
			} else if(MAIN_MENU_OPTION_SEND_BUCKS.equals(choice)) {
				sendBucks();
				//break;
			} else if(MAIN_MENU_OPTION_REQUEST_BUCKS.equals(choice)) {
				requestBucks();
			} else if(MAIN_MENU_OPTION_LOGIN.equals(choice)) {
				login();
			} else {
				// the only other option on the main menu is to exit
				exitProgram();
			}
		}
	}

	private void viewCurrentBalance() throws Exception {
		try {
			Double bal = accountService.getBalance(currentUser.getToken());
			System.out.println("Your current balance is: " + formatter.format(bal));
		}
		catch(Exception e) {

			System.out.println(e.getMessage());
		}
	}

	private void viewTransferHistory() {
		try {
			allTrans = accountService.getTransLog(currentUser.getToken());
			for(Transfer trans : allTrans) {
				System.out.println(trans);
			}
		}
		catch(Exception e) {
			System.out.println(e.getMessage());
		}
	}

	private void viewPendingRequests() {
		// TODO Auto-generated method stub

	}

	private void sendBucks() {
		try {
			allUsers = userService.getAllUsers(currentUser.getToken());
			for(User user : allUsers) {
				System.out.println(user);
			}
		}
		catch(Exception e) {
			System.out.println(e.getMessage());
		}

		TransferCredentials credentials = collectTransferCredentials();
		TransferDTO transDTO = new TransferDTO();
		
		List<Integer> theIds = new ArrayList<Integer>();
		for(User user : allUsers) {
			theIds.add(user.getId());
		}
		if(!theIds.contains(credentials.getTransToId())) {
			System.out.println("\nInvalid Entry");
			return;
		}
		
		if(credentials.getTransAmt() > accountService.getBalance(currentUser.getToken())) {
			transDTO.setAcctTo((long) credentials.getTransToId());
			transDTO.setAmount((double) credentials.getTransAmt());
			transDTO.setStatusId((long) 3);
			transService.addTrans(currentUser.getToken(), transDTO);
			System.out.println("\nInsufficient Funds");
			return;
		}

		else {
			accountService.makeTransfer(currentUser.getToken(), credentials);

			transDTO.setAcctTo((long) credentials.getTransToId());
			transDTO.setAmount((double) credentials.getTransAmt());
			transDTO.setStatusId((long) 2);

			transService.addTrans(currentUser.getToken(), transDTO);
			System.out.println("\nTransfer Complete - " + formatter.format(credentials.getTransAmt()) + " Sent!");
		}
	}

	private TransferCredentials collectTransferCredentials() {
		int transToId = console.getUserInputInteger("Enter a user ID to send bucks to");
		int transAmt  = console.getUserInputInteger("How many TE Bucks would you like to send");
		return new TransferCredentials(transToId, transAmt);
	}

	private void requestBucks() {
		// TODO Auto-generated method stub

	}

	private void exitProgram() {
		System.out.println("Thanks for using TEnmo!");
		System.exit(0);
	}

	private void registerAndLogin() {
		while(!isAuthenticated()) {
			String choice = (String)console.getChoiceFromOptions(LOGIN_MENU_OPTIONS);
			if (LOGIN_MENU_OPTION_LOGIN.equals(choice)) {
				login();
			} else if (LOGIN_MENU_OPTION_REGISTER.equals(choice)) {
				register();
			} else {
				// the only other option on the login menu is to exit
				exitProgram();
			}
		}
	}

	private boolean isAuthenticated() {
		return currentUser != null;
	}

	private void register() {
		System.out.println("Please register a new user account");
		boolean isRegistered = false;
		while (!isRegistered) //will keep looping until user is registered
		{
			UserCredentials credentials = collectUserCredentials();
			try {
				authenticationService.register(credentials);
				isRegistered = true;
				System.out.println("Registration successful. You can now login.");
			} catch(AuthenticationServiceException e) {
				System.out.println("REGISTRATION ERROR: "+e.getMessage());
				System.out.println("Please attempt to register again.");
			}
		}
	}

	private void login() {
		System.out.println("Please log in");
		currentUser = null;
		while (currentUser == null) //will keep looping until user is logged in
		{
			UserCredentials credentials = collectUserCredentials();
			try {
				currentUser = authenticationService.login(credentials);
			} catch (AuthenticationServiceException e) {
				System.out.println("LOGIN ERROR: "+e.getMessage());
				System.out.println("Please attempt to login again.");
			}
		}
	}

	private UserCredentials collectUserCredentials() {
		String username = console.getUserInput("Username");
		String password = console.getUserInput("Password");
		return new UserCredentials(username, password);
	}



}
