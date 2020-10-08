package com.techelevator;

import java.util.Scanner;

public class TempConvert {

	public static void main(String[] args) {
		double convertedTemp = 0;
		double temp = 0;

		Scanner userInput = new Scanner(System.in);
		System.out.println("Please enter a numeric temperature to convert: ");

		String userTemp = userInput.nextLine();

		try {
			temp = Double.parseDouble(userTemp);
		} catch (Exception e) {
			System.out.println(e.getMessage());
			System.out.println("Invalid input! Try again.");
			System.exit(0);
		}

		System.out.println("Is this (C)elsius or (F)ahrenheit? ");
		String userResponse = userInput.nextLine().toLowerCase();

		try {
			if (userResponse.isEmpty()) {
				System.out.println("Is this (C)elsius or (F)ahrenheit? ");
			} else if (userResponse.equals("f") || userResponse.equals("fahrenheit")) {
				convertedTemp = (temp - 32) / 1.8;
				System.out.println(temp + " degrees Fahrenheit is equal to " + convertedTemp + " degrees Celsius.");
			} else if (userResponse.equals("c") || userResponse.equals("celsius")) {
				convertedTemp = temp * 1.8 + 32;
				System.out.println(temp + " degrees Celsius is equal to " + convertedTemp + " degrees Fahrenheit.");
			} else
				System.out.println("Invalid input! Try again.");
				System.exit(0);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		} finally {
			userInput.close();
		}
	}

}
