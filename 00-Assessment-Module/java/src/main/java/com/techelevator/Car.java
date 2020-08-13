package com.techelevator;

public class Car {
	
	private String year;
	private String make;
	private int age;
	private String isClassicCar;
	
	public Car(String year, String make, String isClassicCar) {
		this.year = year;
		this.make = make;
		this.isClassicCar = isClassicCar;
	}

	/**
	 * @return the year
	 */
	public String getYear() {
		return year;
	}

	/**
	 * @param year the year to set
	 */
	public void setYear(String year) {
		this.year = year;
	}

	/**
	 * @return the make
	 */
	public String getMake() {
		return make;
	}

	/**
	 * @param make the make to set
	 */
	public void setMake(String make) {
		this.make = make;
	}

	/**
	 * @return the age
	 */
	public int getAge() {
		return age;
	}

	/**
	 * @param age the age to set
	 */
	public void setAge(int age) {
		this.age = age;
	}

	/**
	 * @return the isClassicCar
	 */
	public String isClassicCar() {
		return isClassicCar;
	}

	/**
	 * @param isClassicCar the isClassicCar to set
	 */
	public void setClassicCar(String isClassicCar) {
		this.isClassicCar = isClassicCar;
	}

	@Override
	public String toString() {
		return "CAR - " + year + " - " + make;
	}
	
	public boolean carNeedsECheck(int yearToCheck) {
		age = 2020 - Integer.parseInt(getYear());
		if(age < 4 || age > 25 || isClassicCar.equals("true")) {
			return false;
		}
		else if(Integer.parseInt(year) % 2 == 0 && yearToCheck % 2 == 0 || Integer.parseInt(year) % 2 != 0 && yearToCheck % 2 != 0) {
			return true;
		}
		return false;
	}
	
	public int ageOfCar() {
		return 2020 - Integer.parseInt(getYear());
	}
	

}
