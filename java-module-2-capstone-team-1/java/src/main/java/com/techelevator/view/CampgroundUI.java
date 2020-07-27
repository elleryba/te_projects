package com.techelevator.view;

import java.text.NumberFormat;
import java.time.LocalDate;
import java.time.Month;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import javax.sql.DataSource;

import org.apache.commons.dbcp2.BasicDataSource;

import com.techelevator.model.campground.Campground;
import com.techelevator.model.campground.CampgroundDAO;
import com.techelevator.model.campground.JdbcCampgroundDAO;
import com.techelevator.model.park.JdbcParkDAO;
import com.techelevator.model.park.Park;
import com.techelevator.model.park.ParkDAO;
import com.techelevator.model.reservation.JdbcReservationDAO;
import com.techelevator.model.reservation.Reservation;
import com.techelevator.model.reservation.ReservationDAO;
import com.techelevator.model.site.JdbcSiteDAO;
import com.techelevator.model.site.Site;
import com.techelevator.model.site.SiteDAO;

public class CampgroundUI {

	/*******************************************************************************************************
	 * This is the CampgroundUI class
	 * 
	 * All user interactions should be coded here
	 * 
	 * The application program will instantiate an object of this class and use the object to interact
	 * with the user.
	 * 
	 * And data required from the user for the application will be acquired by methods of this class
	 * and sent back to the user either as the return value from the method or in an object returned
	 * from the method.
	 * 
	 * Any messages the application programmer wishes to display to the user may be sent to methods of
	 * this class as variables or objects.  Any messaging method may also have "canned" messages the
	 * user may request by a message id.
	 * 
	 *******************************************************************************************************/


	/*******************************************************************************************************
	 * Menu class object
	 * 
	 * Use this Menu object for ALL Menu choices presented to the user
	 * 
	 * This is the same Menu class discussed in module 1 and made available in the module 1 capstone
	 * 
	 * 
	 ******************************************************************************************************/

	//	Menu CampMenu = new Menu(System.in, System.out);  // Define menu for keyboard input and screen output

	/*******************************************************************************************************
	 * Class member variables, objects, constants and methods should be coded here. 
	 ******************************************************************************************************/
	private static final String MAIN_MENU_QUIT = "Exit";
	private static final String MAIN_MENU_DISPLAY_PARK_LIST = "View All Parks";
	private static final String MAIN_MENU_SELECT_PARK = "View Park Info";
	private static final String[] MAIN_MENU_OPTIONS = new String[] {
			MAIN_MENU_DISPLAY_PARK_LIST,
			MAIN_MENU_SELECT_PARK,
			MAIN_MENU_QUIT
	};

	private static final String RETURN_TO_MAIN = "Return to Main Menu";
	private static final String VIEW_CAMPGROUNDS = "View Campgrounds";
	private static final String SEARCH_RESERVATIONS = "Search for Available Reservations";
	private static final String[] SUB_MENU_OPTIONS = new String[] {
			VIEW_CAMPGROUNDS,
			SEARCH_RESERVATIONS,
			RETURN_TO_MAIN
	};

	private static final String RETURN_TO_PREV = "Return to Previous Menu";
	private static final String MAKE_RESERVATION = "Book a Reservation";
	private static final String[] RESERVATION_OPTS = {MAKE_RESERVATION, RETURN_TO_PREV};

	private ParkDAO parkDAO;
	private CampgroundDAO campDAO;
	private SiteDAO siteDAO;
	private ReservationDAO resDAO;
	private Menu menu;

	private NumberFormat formatter = NumberFormat.getCurrencyInstance();

	public static void main(String[] args) {

		BasicDataSource dataSource = new BasicDataSource();
		dataSource.setUrl("jdbc:postgresql://localhost:5432/campground");
		dataSource.setUsername("postgres");
		dataSource.setPassword("postgres1");

		CampgroundUI userInterface = new CampgroundUI(dataSource);
		userInterface.run();
	}

	public CampgroundUI(DataSource dataSource) {
		this.menu = new Menu(System.in, System.out);
		parkDAO = new JdbcParkDAO(dataSource);
		campDAO = new JdbcCampgroundDAO(dataSource);
		siteDAO = new JdbcSiteDAO(dataSource);
		resDAO = new JdbcReservationDAO(dataSource);
	}

	public void run() {

		System.out.println("Welcome!");

		boolean shouldProcess = true;
		while(shouldProcess) {

			String choice = (String)menu.getChoiceFromOptions(MAIN_MENU_OPTIONS);

			switch(choice) {

			case MAIN_MENU_DISPLAY_PARK_LIST:
//				List<Park> theParks = parkDAO.getAllParks();
//				parkChoice(theParks);
				List<Park> parks = parkDAO.getAllParks();
				int i=1;
				for(Park park : parks) {
					String parkName = park.getName();
					System.out.println(i + " - " + parkName);
					i++;
				}

				break;

			case MAIN_MENU_SELECT_PARK:

				System.out.println("Enter a Park Number");
				Scanner userInput = new Scanner(System.in);
				String userResponse = userInput.nextLine();
				//String parkName = parkDAO.getAllParks().get(Integer.parseInt(userResponse)-1).getName();

				try {
					System.out.println(parkDAO.getAllParks().get(Integer.parseInt(userResponse)-1));
				}
				catch(IndexOutOfBoundsException e) {
					System.out.println("Invalid entry - Don't get cute...");
					break;
				}

				boolean shouldProcessCamp = true;
				while(shouldProcessCamp) {
					System.out.println("\nSelect a Command");
					String campChoice = (String)menu.getChoiceFromOptions(SUB_MENU_OPTIONS);

					switch(campChoice) {
					case VIEW_CAMPGROUNDS:

						handleViewCampgrounds(parkDAO.getAllParks().get(Integer.parseInt(userResponse)-1));
						break;
					case SEARCH_RESERVATIONS:
						System.out.println("Enter a Campground Name");
						String userCamp = userInput.nextLine();

						if(campDAO.getCampgroundsByName(userCamp).isEmpty()) {
							System.out.println("Invalid entry - Don't get cute...");
							break;
						}
						System.out.println("Enter an arrival and departure date, separated by a comma \n(YYYY-MM-DD, YYYY-MM-DD)");
						
						String userDates = userInput.nextLine();
						
						String[] dates = userDates.split(", ");

						List<Site> availSites = new ArrayList<Site>();

						try {
							availSites = siteDAO.getAvailableSites(campDAO.getCampgroundsByName(userCamp).get(0).getCampgroundId(), LocalDate.parse(dates[0]),
									LocalDate.parse(dates[1]));
							if(availSites.size() == 0) {
								System.out.println("No available sites found. \nWould you like to change your search criteria? Y/N");
								String dateResponse = userInput.nextLine();

								if(dateResponse.toUpperCase().equals("Y")) {
									campChoice = SEARCH_RESERVATIONS;
									break;
								}
								if(dateResponse.toUpperCase().equals("N")) {
									shouldProcessCamp = false;
									break;
								}
							}
							if(availSites.size() >= 1) {
								for(Site s : availSites) {
									System.out.println(s);
								}
								System.out.println("\nTotal cost for reservation at " + userCamp + ": " + formatter.format(siteDAO.getTotalBill(campDAO.getCampgroundsByName(userCamp).get(0).getCampgroundId(), LocalDate.parse(dates[0]), LocalDate.parse(dates[1]))));
							}
						}
						catch(Exception e) {
							System.out.println("Invalid entry");
							break;

						}

						boolean shouldProcessRes = true;
						while(shouldProcessRes) {
							System.out.println("\nSelect a Command");
							String makeResChoice = (String)menu.getChoiceFromOptions(RESERVATION_OPTS);

							switch(makeResChoice) {

							case MAKE_RESERVATION:
								//								System.out.println("Enter a campground ID");
								//								Long campId = Long.parseLong(userInput.nextLine());
								//								
								//								System.out.println("Enter a Site ID");
								//								Long siteId = Long.parseLong(userInput.nextLine());

								System.out.println("Enter your first and last name");
								String name = userInput.nextLine();

								resDAO.makeNewReservation(availSites.get(0).getSite_id(), name, LocalDate.parse(dates[0]), LocalDate.parse(dates[1]));

								System.out.println("Your reservation has been booked! Your confirmation ID is: " + resDAO.getLatestResId());
								shouldProcessRes = false;
								shouldProcessCamp = false;
								break;

							case RETURN_TO_PREV:
								shouldProcessRes = false;
								break;
							}

						}
						break;

					case RETURN_TO_MAIN:
						shouldProcessCamp = false;
						break;
					}
				}
				break;
			case MAIN_MENU_QUIT:
				System.out.println("Goodbye - and remember, smile while you camp!");
				shouldProcess = false;
				break;
			}
		}
	}

	private void handleViewCampgrounds(Park park) {

		List<Campground> campgrounds = campDAO.getCampgroundsByParkId(park.getPark_id());
		if(!campgrounds.isEmpty()) {
			System.out.println(park.getName() + " Campgrounds");
			System.out.println(String.format("%-35s %-15s %-15s %-15s", "Name", "Open", "Close", "Daily Fee"));
			for(Campground camp: campgrounds) {
				String campName = camp.getName().toString();
				String openFrom = monthNumberToName(camp.getOpenFrom().toString());
				String openTo = monthNumberToName(camp.getOpenTo().toString());
				String dailyFee = String.valueOf(camp.getDailyFee());

				System.out.println(String.format("%-35s %-15s %-15s %-15s", campName, openFrom, openTo, formatter.format(Double.parseDouble(dailyFee))));
				//move formatting to getCamprounds method
			}
		}
		if(campgrounds.isEmpty()) {
			System.out.println("No campgrounds found for the selected park!");
		}
	}
	
	private String monthNumberToName(String month) {
		String monthString = "";
	        switch (Integer.parseInt(month)) {
	            case 1:  monthString = "January";
	                     break;
	            case 2:  monthString = "February";
	                     break;
	            case 3:  monthString = "March";
	                     break;
	            case 4:  monthString = "April";
	                     break;
	            case 5:  monthString = "May";
	                     break;
	            case 6:  monthString = "June";
	                     break;
	            case 7:  monthString = "July";
	                     break;
	            case 8:  monthString = "August";
	                     break;
	            case 9:  monthString = "September";
	                     break;
	            case 10: monthString = "October";
	                     break;
	            case 11: monthString = "November";
	                     break;
	            case 12: monthString = "December";
	                     break;
	            default: monthString = "Invalid month";
	                     break;
	        }
	        return monthString;
	}
	
	public String parkChoice(List<Park> parks) {
		
		String[] allParks = new String[parkDAO.getAllParks().size()];
		List<Park> theParks = parkDAO.getAllParks();
		
		int i=0;
		for(Park p : theParks) {
			allParks[i] = p.getName();
			i++;
		}
		
		String parkChoice = (String)menu.getChoiceFromOptions(allParks);
		return parkChoice;
	}
}