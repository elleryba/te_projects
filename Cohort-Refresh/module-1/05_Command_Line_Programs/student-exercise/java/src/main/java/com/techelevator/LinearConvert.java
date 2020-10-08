package com.techelevator;

import java.util.Scanner;

public class LinearConvert {

	public static void main(String[] args) {
		double userLength = 0;
		double convertedLength = 0;
		Scanner userInput = new Scanner(System.in);

		System.out.println("Please enter a numeric length to convert: ");

		try {
			userLength = Double.parseDouble(userInput.nextLine());
		} catch (Exception e) {
			System.out.println(e.getMessage());
			System.out.println("Invalid input! Try again.");
			System.exit(0);
		}
		System.out.println("Is the measurement in (m)eters or (f)eet? ");
		String userResponse = userInput.nextLine().toLowerCase();

		try {
			if (userResponse.toLowerCase().equals("m") || userResponse.toLowerCase().equals("meters")) {
				convertedLength = userLength * 3.2808399;
				System.out.println(userLength + "m is equal to " + convertedLength + "f.");
			} else if (userResponse.toLowerCase().equals("f") || userResponse.toLowerCase().equals("feet")) {
				convertedLength = userLength * 0.3048;
				System.out.println(userLength + "f is equal to " + convertedLength + "m.");
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
