package com.techelevator.tenmo.models;

public class TransferCredentials {
	
	private int transToId;
	private int transAmt;
	
	
	
	
	
	public TransferCredentials(int transToId, int transAmt) {		
		this.transToId = transToId;
		this.transAmt = transAmt;
	}
	
	@Override
	public String toString() {
		return "TransferCredentials transToId: " + transToId + ", transAmt: " + transAmt;
	}

	public int getTransToId() {
		return transToId;
	}
	public int getTransAmt() {
		return transAmt;
	}
	public void setTransToId(int transToId) {
		this.transToId = transToId;
	}
	public void setTransAmt(int transAmt) {
		this.transAmt = transAmt;
	}
	
	

}
