package com.techelevator.tenmo.controller;

import java.security.Principal;
import java.util.List;

import org.springframework.http.HttpStatus;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import com.techelevator.tenmo.dao.AccountsDAO;
import com.techelevator.tenmo.dao.TransferDAO;
import com.techelevator.tenmo.dao.UserDAO;
import com.techelevator.tenmo.model.Accounts;
import com.techelevator.tenmo.model.Transfer;
import com.techelevator.tenmo.model.TransferDTO;

@RestController
@RequestMapping("/transfers")
@PreAuthorize("isAuthenticated()")
public class TransferController {
	
	private AccountsDAO acctDAO;
	private UserDAO userDAO;
	private TransferDAO transDAO;
	
	public TransferController(AccountsDAO acctDAO, UserDAO userDAO, TransferDAO transDAO) {
		this.acctDAO = acctDAO;
		this.userDAO = userDAO;
		this.transDAO = transDAO;
	}
	
	//works in postman
	//the method below allows an authenticated user to search for Transfers by their ID
	//this method works server-side, but there was no clear place to implement this
	//	method in the App for the user to interact with
	@RequestMapping(path = "/{id}", method = RequestMethod.GET)
	public List<Transfer> getTrans(@PathVariable Long id, Principal thePal) {
		List<Transfer> theTrans = transDAO.getById(id);
		return theTrans;
	}
	
	@RequestMapping(method = RequestMethod.POST)
	@ResponseStatus(HttpStatus.CREATED)
	public void storeTrans(Principal thePal, @RequestBody TransferDTO creds) {
		Long userId = (long) userDAO.findIdByUsername(thePal.getName());
		Accounts anAcct = acctDAO.getAcctByUserId(userId);
		
		transDAO.addTrans(creds.getTypeId(), creds.getStatusId(), anAcct.getId(), creds.getAcctTo(),  creds.getAmount());
	}

}
