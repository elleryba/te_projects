package com.techelevator;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/*
 In case you've ever pondered how much you weight on Mars, here's the calculation:
 	Wm = We * 0.378
 	where 'Wm' is the weight on Mars, and 'We' is the weight on Earth
 
Write a command line program which accepts a series of Earth weights from the user  
and displays each Earth weight as itself, and its Martian equivalent.

 $ MartianWeight 
 
Enter a series of Earth weights (space-separated): 98 235 185
 
 98 lbs. on Earth, is 37 lbs. on Mars.
 235 lbs. on Earth, is 88 lbs. on Mars.
 185 lbs. on Earth, is 69 lbs. on Mars. 
 */
public class MartianWeight {

	public static void main(String[] args) {
		Scanner userInput = new Scanner(System.in);
		List<Integer> weightList = new ArrayList<Integer>();

		System.out.print("Enter a seres of Earth weights, separated by spaces: ");
		String userResponse = userInput.nextLine();

		try {
			String[] userWeights = userResponse.split(" ");
			for (String s : userWeights) {
				weightList.add(Integer.parseInt(s));
			}
			for (int i : weightList) {
				int marsW = (int) (i * 0.378);
				System.out.println(i + "lbs on Earth is " + marsW + "lbs on Mars.");
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
