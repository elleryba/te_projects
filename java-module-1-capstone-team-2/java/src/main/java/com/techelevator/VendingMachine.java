package com.techelevator;

//last updated 7/27/2020 10:45am by eryba

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.text.DateFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeMap;

public class VendingMachine {
	private double currentBalance = 0.00;
	private Map<String, Slot> inventory;
	private String auditLine = ""; // need for reportAuditLine();
	private NumberFormat formatter = NumberFormat.getCurrencyInstance();

	public VendingMachine() throws FileNotFoundException {
		inventory = new TreeMap<String, Slot>();
		loadInventory();
	}

	public void loadInventory() throws FileNotFoundException {

		File inventoryFile = new File("vendingmachine.csv");
		Scanner inputFile = new Scanner(inventoryFile);

		while (inputFile.hasNext()) {
			String aLine = inputFile.nextLine();
			String[] inventoryData = aLine.split("\\|");
			VendingMachineItem anItem = new VendingMachineItem(inventoryData[1], inventoryData[3]);
			Slot aSlot = new Slot(anItem, Double.parseDouble(inventoryData[2]), 5);
			inventory.put(inventoryData[0], aSlot);
		}

	}

	public void displayInventory() {
		Set<String> theKeys = inventory.keySet(); // Get all the keys from the Map

		for (String aKey : theKeys) { // loop through the keys from the map
			if (inventory.get(aKey).getQuantity() == 0) {
				System.out.println(aKey + ") " + inventory.get(aKey) + " SOLD OUT");
			} else {
				System.out.println(aKey + ") " + inventory.get(aKey));
			}
		}
	}

	public void depositMoney() throws IOException {

		System.out.println("Current Money Provided: " + formatter.format(currentBalance));
		Scanner userInput = new Scanner(System.in);

		System.out.println(
				"Please enter the amount of money to be deposited. Machine accepts $1, $2, $5, or $10 bills only.");
		String userResponse = userInput.nextLine();
		String moneyToDeposit = userResponse;
		double userMoney = Double.parseDouble(moneyToDeposit);

		if (userMoney != 1.0 && userMoney != 2.0 && userMoney != 5.0 && userMoney != 10.0) {
			System.out.println("Invalid entry");
		}

		else {
			currentBalance += userMoney;
			System.out.println("Current Money Provided: " + formatter.format(currentBalance));

			recordAuditLine("FEED MONEY:", formatter.format(userMoney));// records a line with a transaction
		}
	}

	public void dispenseItem() throws IOException {
		System.out.println("\nEnter item location with letter/number combination:");
		Scanner userInput = new Scanner(System.in);
		String userResponse = userInput.nextLine().toUpperCase();

		if (!inventory.containsKey(userResponse)) {
			System.out.println("Invalid Entry");
		}

		if (inventory.containsKey(userResponse)) {
			int currentQuantity = inventory.get(userResponse).getQuantity();

			if (currentBalance >= inventory.get(userResponse).getPrice()) {

				if (currentQuantity >= 1) {
					inventory.get(userResponse).setQuantity(currentQuantity - 1);
					currentBalance -= inventory.get(userResponse).getPrice();

					String itemTypeMessage = "";
					String slotItemString = inventory.get(userResponse).getSlotItem().toString();
					String[] splitString = slotItemString.trim().split("\\|");

					if (splitString[0].contains("Chip")) {
						itemTypeMessage = "Crunch Crunch, Yum!";
					}
					if (splitString[0].contains("Candy")) {
						itemTypeMessage = "Munch Munch, Yum!";
					}
					if (splitString[0].contains("Drink")) {
						itemTypeMessage = "Glug Glug, Yum!";
					}
					if (splitString[0].contains("Gum")) {
						itemTypeMessage = "Chew Chew, Yum!";
					}

					System.out.println(splitString[1] + " " + formatter.format(inventory.get(userResponse).getPrice())
							+ " Your current balance is now: " + formatter.format(currentBalance) + " "
							+ itemTypeMessage);

					recordAuditLine(inventory.get(userResponse).getSlotItem().getName() + " " + userResponse,
							formatter.format(currentBalance) + " "
									+ formatter.format(inventory.get(userResponse).getPrice()));
					// ^ records a line of a transaction
				}

				else {
					System.out.println("SOLD OUT");
				}
			}

			else if (currentBalance < inventory.get(userResponse).getPrice()) {
				System.out.println("Insufficient funds");
			}
		}
	}

	public void writeSalesReport() throws IOException {

		Date date = new Date();
		DateFormat dateFormat = new SimpleDateFormat("MM-dd-yyyy hhmm a");

		String formattedDate = dateFormat.format(date);

		File salesReport = new File(formattedDate + " salesReport.txt");
		salesReport.createNewFile();
		PrintWriter addToSalesReport = new PrintWriter(salesReport);

		Set<String> theKeys = inventory.keySet(); // Get all the keys from the Map

		double totalSales = 0.00;

		try {

			for (String aKey : theKeys) {
				Slot newSlot = inventory.get(aKey);
				int quantitySold = 5 - newSlot.getQuantity();
				totalSales = totalSales + (quantitySold * newSlot.getPrice());
				addToSalesReport.println(newSlot.getSlotItem().getName() + "|" + quantitySold);
			}

			addToSalesReport.println("\nTotal sales: " + formatter.format(totalSales));
		}

		finally {
			addToSalesReport.close();
		}
	}

	private void recordAuditLine(String userAction, String string) throws IOException {
		// takes all the transaction lines recorded at puts them into one string

		Date date = new Date();
		DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy hh:mm a");
		String formattedDate = dateFormat.format(date);

		auditLine += (formattedDate + " " + userAction + " " + string + " " + formatter.format(currentBalance) + "\n");
	}

	public void writeTransactionReport() throws IOException { // writes the transaction report by taking the auditLine

		File transactionReport = new File("Log.txt");
		transactionReport.createNewFile();
		PrintWriter addToTransactionReport = new PrintWriter(transactionReport);

		addToTransactionReport.print(auditLine);

		addToTransactionReport.close();
	}

	public void finishTransaction() throws IOException {

		int quarters = 0;
		int dimes = 0;
		int nickels = 0;
		double moneyBeforeChange = currentBalance;

		while (currentBalance > .249999) {
			quarters++;
			currentBalance -= .25;
		}

		while (currentBalance > .099999) {
			dimes++;
			currentBalance -= .10;
		}

		while (currentBalance > 0.049999) {
			nickels++;
			currentBalance -= .05;
		}

		currentBalance = 0;

		System.out.println(
				"\nDispensing Change" + "\nQuarters: " + quarters + "\nDimes: " + dimes + "\nNickels: " + nickels);

		recordAuditLine("GIVE CHANGE:", formatter.format(moneyBeforeChange));
	}

	public Map<String, Slot> getInventory() {
		return inventory;
	}

	public double getCurrentBalance() {
		return currentBalance;
	}

	/**
	 * @param currentBalance the currentBalance to set
	 */
	public void setCurrentBalance(double currentBalance) {
		this.currentBalance = currentBalance;
	}

	/**
	 * @param inventory the inventory to set
	 */
	public void setInventory(Map<String, Slot> inventory) {
		this.inventory = inventory;
	}

	/**
	 * @param auditLine the auditLine to set
	 */
	public void setAuditLine(String auditLine) {
		this.auditLine = auditLine;
	}
}
