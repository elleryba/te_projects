package com.techelevator.tenmo.controller;

import java.util.List;

import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.techelevator.tenmo.dao.AccountsDAO;
import com.techelevator.tenmo.dao.TransferDAO;
import com.techelevator.tenmo.dao.UserDAO;
import com.techelevator.tenmo.model.User;

@RestController
@RequestMapping("/user")
@PreAuthorize("isAuthenticated()")

public class UserController {
	
	private AccountsDAO acctDAO;
	private UserDAO userDAO;
	private TransferDAO transDAO;
	
	public UserController(AccountsDAO acctDAO, UserDAO userDAO, TransferDAO transDAO) {
		this.acctDAO = acctDAO;
		this.userDAO = userDAO;
		this.transDAO = transDAO;
	}
	
	//works in postman
	@RequestMapping(path = "/allusers", method = RequestMethod.GET)
	public List<User> getAllUsers(){
		List<User> theUsers = userDAO.findAll();

		return theUsers;
	}

}
