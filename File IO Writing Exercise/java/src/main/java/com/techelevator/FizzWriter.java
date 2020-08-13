package com.techelevator;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

public class FizzWriter {

	public static void main(String[] args) throws IOException {

		File myFile = new File("FizzBuzz.txt");
		myFile.createNewFile();
		PrintWriter writer = new PrintWriter(myFile);
		
		int n = 1;
		int[] integerArray = new int[300]; 
		for(int i = 0; i < integerArray.length; i++) {
			integerArray[i] = n;
			n+=1;
		}
		
//		for(int numberInArray : integerArray) {
//			System.out.println(numberInArray);
//		}
		
		try { 
			for(int numberInArray : integerArray) {
				
				if (numberInArray %3 == 0 && numberInArray %5 == 0) {
					writer.println("FizzBuzz");
				}
				else if (numberInArray %3==0) {
					writer.println("Fizz");
				}
				else if (numberInArray %5 ==0) {
					writer.println("Buzz");
				}
				else {
					writer.println(numberInArray);
				}
			}
		}
		
		finally {
			writer.close();
		}
	}
}