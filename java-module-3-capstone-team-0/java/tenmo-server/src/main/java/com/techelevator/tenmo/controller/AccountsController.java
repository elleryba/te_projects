package com.techelevator.tenmo.controller;

import java.security.Principal;
import java.util.List;

import org.springframework.http.HttpStatus;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import com.techelevator.tenmo.dao.AccountsDAO;
import com.techelevator.tenmo.dao.TransferDAO;
import com.techelevator.tenmo.dao.UserDAO;
import com.techelevator.tenmo.model.AccountTransferDTO;
import com.techelevator.tenmo.model.Accounts;
import com.techelevator.tenmo.model.Transfer;

@RestController
@RequestMapping("/account")
@PreAuthorize("isAuthenticated()")
public class AccountsController {
	
	private AccountsDAO acctDAO;
	private UserDAO userDAO;
	private TransferDAO transDAO;
	
	public AccountsController(AccountsDAO acctDAO, UserDAO userDAO, TransferDAO transDAO) {
		this.acctDAO = acctDAO;
		this.userDAO = userDAO;
		this.transDAO = transDAO;
	}
	
	//works in postman
	@RequestMapping(path = "/balance", method = RequestMethod.GET)
	public double getBal(Principal thePrincipal) {
		Long userId = (long) userDAO.findIdByUsername(thePrincipal.getName());
		
		return acctDAO.getAcctByUserId(userId).getBalance();

	}
	
	@RequestMapping(path = "/log", method = RequestMethod.GET)
	public List<Transfer> getTrans(Principal thePrincipal){
		Long userId = (long) userDAO.findIdByUsername(thePrincipal.getName());
		Accounts anAcct = acctDAO.getAcctByUserId(userId);
		
		List<Transfer> theTrans = transDAO.listTransByAcct(anAcct.getId(), anAcct.getId());
		return theTrans;
	}
	
	//works in postman
	@RequestMapping(path = "/transfer", method = RequestMethod.PUT)
	@ResponseStatus(HttpStatus.ACCEPTED)
	public void makeTransfer(Principal thePrincipal, @RequestBody AccountTransferDTO newTransfer) {
		Long userId = (long) userDAO.findIdByUsername(thePrincipal.getName());
		Accounts anAcct = acctDAO.getAcctByUserId(userId);
		System.out.println("Printing data from makeTransfer() in AccountsController");
		System.out.println("From account = " + anAcct.getId());
		System.out.println("to account = " + newTransfer.getTransToId());
		acctDAO.updateBalanceAdd(newTransfer.getTransToId(), newTransfer.getTransAmt());
		acctDAO.updateBalanceSubtract(anAcct.getId(), newTransfer.getTransAmt());
	}

}
