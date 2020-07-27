package com.techelevator.tenmo.model;

public class AccountTransferDTO {
	
	private Long transToId;
	private Double transAmt;
	
	

	public Long getTransToId() {
		return transToId;
	}

	public Double getTransAmt() {
		return transAmt;
	}

	public void setTransToId(Long transToId) {
		this.transToId = transToId;
	}

	public void setTransAmt(Double transAmt) {
		this.transAmt = transAmt;
	}

    @Override
	public String toString() {
		return "AccountTransferDTO transToId: " + transToId + ", transAmt: " + transAmt;
	

}
}