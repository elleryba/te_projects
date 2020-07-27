package com.techelevator.tenmo.models;

public class TransferDTO {
	
	private Long typeId = (long) 2;
	private Long statusId;	
	private Long acctTo;
	private Double amount;
	
	
	@Override
	public String toString() {
		return "TransferDTO typeId: " + typeId + ", statusId: " + statusId + ", acctTo: "
				+ acctTo + ", amount: " + amount;
	}
	
	public Long getTypeId() {
		return typeId;
	}
	public Long getStatusId() {
		return statusId;
	}

	public Long getAcctTo() {
		return acctTo;
	}
	public Double getAmount() {
		return amount;
	}
	public void setTypeId(Long typeId) {
		this.typeId = typeId;
	}
	public void setStatusId(Long statusId) {
		this.statusId = statusId;
	}
	
	public void setAcctTo(Long acctTo) {
		this.acctTo = acctTo;
	}
	public void setAmount(Double amount) {
		this.amount = amount;
	}
	

}
