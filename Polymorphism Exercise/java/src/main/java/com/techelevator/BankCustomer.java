package com.techelevator;

import java.util.ArrayList;
import java.util.List;

/**
 * BankCustomer
 */
public class BankCustomer {

	private String name;
	private String address;
	private String phoneNumber;
	
	public BankCustomer() {
		this.name = name;
		this.address = address;
		this.phoneNumber = phoneNumber;
	}
	
	
	
	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @return the address
	 */
	public String getAddress() {
		return address;
	}

	/**
	 * @param address the address to set
	 */
	public void setAddress(String address) {
		this.address = address;
	}

	/**
	 * @return the phoneNumber
	 */
	public String getPhoneNumber() {
		return phoneNumber;
	}

	/**
	 * @param phoneNumber the phoneNumber to set
	 */
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}



	/**
	 * @return the accounts
	 */
	public List<Accountable> getAccounts() {
		return accounts;
	}



	List<Accountable> accounts = new ArrayList<>();
	
	public Accountable[] addAccount(Accountable newAccount) {
		return accounts.toArray(new Accountable[accounts.size()]);
	}

	public boolean isVip() {
		int sum = 0;
		for (Accountable i : accounts) {
			sum += i.getBalance();
		}
		return sum > 25000;
	}
    
}