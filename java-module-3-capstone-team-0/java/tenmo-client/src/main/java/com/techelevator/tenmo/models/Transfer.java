package com.techelevator.tenmo.models;

import java.text.NumberFormat;

public class Transfer {

	private Long id;
	private Long typeId;
	private Long statusId;
	private Long acctFrom;
	private Long acctTo;
	private Double amount;
	private NumberFormat formatter = NumberFormat.getCurrencyInstance();
	
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
	 * @return the typeId
	 */
	public Long getTypeId() {
		return typeId;
	}

	/**
	 * @param typeId the typeId to set
	 */
	public void setTypeId(Long typeId) {
		this.typeId = typeId;
	}

	/**
	 * @return the statusId
	 */
	public Long getStatusId() {
		return statusId;
	}

	/**
	 * @param statusId the statusId to set
	 */
	public void setStatusId(Long statusId) {
		this.statusId = statusId;
	}

	/**
	 * @return the acctFrom
	 */
	public Long getAcctFrom() {
		return acctFrom;
	}

	/**
	 * @param acctFrom the acctFrom to set
	 */
	public void setAcctFrom(Long acctFrom) {
		this.acctFrom = acctFrom;
	}

	/**
	 * @return the acctTo
	 */
	public Long getAcctTo() {
		return acctTo;
	}

	/**
	 * @param acctTo the acctTo to set
	 */
	public void setAcctTo(Long acctTo) {
		this.acctTo = acctTo;
	}

	/**
	 * @return the amount
	 */
	public Double getAmount() {
		return amount;
	}

	/**
	 * @param amount the amount to set
	 */
	public void setAmount(Double amount) {
		this.amount = amount;
	}

	@Override
	public String toString() {
		return "Transfer ID: " + id + " Amount: " + formatter.format(amount) + " Sent From Account ID: " + acctFrom + " Sent To Account ID: " + acctTo;
	}
}
