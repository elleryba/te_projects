package com.techelevator;

import java.util.Scanner;

public class Fibonacci {

	public static void main(String[] args) {
		int sum = 0;
		int x1 = 0;
		int x2 = 1;
		int userNum = 0;
		Scanner userInput = new Scanner(System.in);

		System.out.print("Please enter the Fibonacci number: ");
		String userResponse = userInput.nextLine();

		try {
			userNum = Integer.parseInt(userResponse);
			
			while (x1 <= userNum) {
					System.out.println(x1);
					sum = x1 + x2;
					x1 = x2;
					x2 = sum;
			}
		} catch (Exception e) {
			System.out.println(e.getMessage());
			System.out.println("Invalid input! Try again.");
			System.exit(0);
		} finally {
			userInput.close();
		}
	}
}
