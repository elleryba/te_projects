package com.techelevator;

import java.util.Scanner;

public class DecimalToBinary {

	public static void main(String[] args) {
		Scanner userInput = new Scanner(System.in);

		System.out.println("Please enter a series of decimal values, separated by spaces: ");
		String userResponse = userInput.nextLine();

		try {
			String[] splitString = userResponse.split(" ");

			for (String s : splitString) {
				System.out.println(s + " in binary is " + Integer.toBinaryString(Integer.parseInt(s)));
			}
		} catch (Exception e) {
			System.out.println(e.getMessage());
			System.out.println("Invalid entry! Try again.");
			System.exit(0);
		} finally {
			userInput.close();
		}
	}
}
