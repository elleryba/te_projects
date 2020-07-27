package com.techelevator.tenmo.dao;

import java.util.List;

import com.techelevator.tenmo.model.Accounts;

public interface AccountsDAO {
	
	Accounts getAcctByUserId(Long userId);
	
	double getBalanceByUser(String username);
	
	void updateBalanceAdd(Long acctId, Double amt);
	
	void updateBalanceSubtract(Long acctId, Double amt);
	
}
