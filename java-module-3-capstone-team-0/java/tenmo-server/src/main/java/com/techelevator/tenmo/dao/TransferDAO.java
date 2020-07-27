package com.techelevator.tenmo.dao;

import java.util.List;

import com.techelevator.tenmo.model.Transfer;

public interface TransferDAO {
	
	List<Transfer> getById(Long transId);
	
	//List<Transfer> getAllTrans();
	
	void addTrans(Long typeId, Long statusId, Long acctFrom, Long acctTo, Double amount);
	
	List<Transfer> listTransByAcct(Long acctFrom, Long acctTo);

}
