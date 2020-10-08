package com.techelevator;

import java.text.NumberFormat;
import java.util.Scanner;

/*
 Write a command line program which prompts the user for the total bill, and the amount tendered. It should then
 display the change required.

 $ java MakeChange
 Please enter the amount of the bill: 23.65
 Please enter the amount tendered: 100.00
 The change required is 76.35
 */
public class MakeChange {

	public static void main(String[] args) {
		double change = 0;
		double billAmt = 0;
		double tenderedAmt = 0;
		NumberFormat formatter = NumberFormat.getCurrencyInstance();
		Scanner userInput = new Scanner(System.in);

		System.out.print("Please enter the amount of the bill: $");
		String userResponse = userInput.nextLine();

		try {
			billAmt = Double.parseDouble(userResponse);
		} catch (Exception e) {
			System.out.println(e.getMessage());
			System.out.println("Invalid entry! Try again.");
			System.exit(0);
		}

		System.out.print("Please enter the amount tendered: $");
		userResponse = userInput.nextLine();

		try {
			tenderedAmt = Double.parseDouble(userResponse);
		} catch (Exception e) {
			System.out.println(e.getMessage());
			System.out.println("Invalid entry! Try again.");
			System.exit(0);
		} finally {
			userInput.close();
		}

		change = tenderedAmt - billAmt;
		System.out.println("The change required is " + formatter.format(change));
	}
}
