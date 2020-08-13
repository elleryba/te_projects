package com.techelevator;

/**
 * CreditCardAccount
 */
public class CreditCardAccount implements Accountable {
	
	private String accountHolder;
	private String accountNumber;
	private int debt = 0;
	
	public CreditCardAccount(String accountHolder, String accountNumber) {
		this.accountHolder = accountHolder;
		this.accountNumber = accountNumber;
	}


    /**
	 * @return the accountHolder
	 */
	public String getAccountHolder() {
		return accountHolder;
	}




	/**
	 * @return the accountNumber
	 */
	public String getAccountNumber() {
		return accountNumber;
	}




	/**
	 * @return the debt
	 */
	public int getDebt() {
		return debt;
	}

	public int pay(int amountToPay) {
		int newBalance = debt - amountToPay;
		debt = newBalance;
		return debt;
	}
	
	public int charge(int amountToCharge) {
		int newAmountOwed = debt + amountToCharge;
		debt = newAmountOwed;
		return debt;
	}


	public int getBalance() {
    	//***************************************************************
    	// This should return the negative of the debt data member
    	//***************************************************************
    	
        return -debt;
    }

 

}