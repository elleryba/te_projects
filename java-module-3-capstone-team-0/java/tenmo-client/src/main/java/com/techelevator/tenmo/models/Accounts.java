package com.techelevator.tenmo.models;

import java.math.BigDecimal;

public class Accounts {

	private Long id;
	private Long userId;
	private BigDecimal balance;
	
	public Accounts(Long id, Long userId, BigDecimal balance) {
		
		this.id = id;
		this.userId = userId;
		this.balance = balance;
	}
	
	/**
	 * @return the id
	 */
	public Long getId() {
		return id;
	}
	/**
	 * @param id the id to set
	 */
	public void setId(Long id) {
		this.id = id;
	}
	/**
	 * @return the userId
	 */
	public Long getUserId() {
		return userId;
	}
	/**
	 * @param userId the userId to set
	 */
	public void setUserId(Long userId) {
		this.userId = userId;
	}
	/**
	 * @return the balance
	 */
	public BigDecimal getBalance() {
		return balance;
	}
	/**
	 * @param balance the balance to set
	 */
	public void setBalance(BigDecimal balance) {
		this.balance = balance;
	}
	@Override
	public String toString() {
		return "Account balance : $" + balance;
	}

}
