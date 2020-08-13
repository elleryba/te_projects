package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

public class Module1CodingAssessment {

	public static void main(String[] args) throws FileNotFoundException {

		Map<Integer, Car> carInventory = new HashMap<Integer, Car>();

		File carInputFile = new File("CarInput.csv");
		Scanner inputFile = new Scanner(carInputFile);
		int i = 1;
		int ageAllCars = 0;

		while(inputFile.hasNextLine()) {
			String aLine = inputFile.nextLine();
			String[] carData = aLine.split(",");
			Car newCar = new Car(carData[0], carData[1], carData[2]);
			carInventory.put(i, newCar);
			i++;
			ageAllCars += 2020 - Integer.parseInt(carData[0]);
		}
		inputFile.close();

		/*Set<Integer> theCars = carInventory.keySet();
		for(int aCar : theCars) {
			System.out.println(aCar + ") " + carInventory.get(aCar));
			}
		 */
		System.out.println("Age of all cars combined totals: " + ageAllCars);
	}
}
