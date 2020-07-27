package com.techelevator.tenmo.dao;

import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Service;

import com.techelevator.tenmo.model.Accounts;

@Service
public class JdbcAccountsDAO implements AccountsDAO {
	
	private JdbcTemplate jdbcTemplate;
	
	public JdbcAccountsDAO(JdbcTemplate jdbcTemplate) {
		this.jdbcTemplate = jdbcTemplate;
	}

	@Override
	public double getBalanceByUser(String username) {
		Accounts anAcct = null;
		String getBalSql = "SELECT balance FROM accounts INNER JOIN users ON users.user_id = accounts.user_id WHERE users.user_id = ?;";
		
		SqlRowSet result = jdbcTemplate.queryForRowSet(getBalSql, username);
		
		while(result.next()) {
			anAcct = MapRowToAccount(result);
		}
		
		return anAcct.getBalance();
	}
	
	@Override
	public void updateBalanceAdd(Long acctId, Double amt) {
		Accounts anAcct = null;
		String getAcctSql = "SELECT * FROM accounts WHERE accounts.account_id = ?;";		
		SqlRowSet result = jdbcTemplate.queryForRowSet(getAcctSql, acctId);
		while(result.next()) {
			anAcct = MapRowToAccount(result);
		}
		
		String updateSql = "UPDATE accounts SET balance = ? WHERE accounts.account_id = ?;";
		jdbcTemplate.update(updateSql, (anAcct.getBalance() + amt), acctId);
	}
	
	@Override
	public void updateBalanceSubtract(Long acctId, Double amt) {
		Accounts anAcct = null;
		String getAcctSql = "SELECT * FROM accounts WHERE accounts.account_id = ?;";
		
		SqlRowSet result = jdbcTemplate.queryForRowSet(getAcctSql, acctId);
		while(result.next()) {
			anAcct = MapRowToAccount(result);
		}
		
		String updateSql = "UPDATE accounts SET balance = ? WHERE accounts.account_id = ?;";
		jdbcTemplate.update(updateSql, (anAcct.getBalance() - amt), acctId);
	}
	
	@Override
	public Accounts getAcctByUserId(Long userId) {
		Accounts anAcct = null;
		String getAcctSql = "SELECT * FROM accounts INNER JOIN users ON users.user_id = accounts.user_id WHERE users.user_id = ?;";
		
		SqlRowSet result = jdbcTemplate.queryForRowSet(getAcctSql, userId);
		while(result.next()) {
			anAcct = MapRowToAccount(result);
		}
		return anAcct;
	}
	
	private Accounts MapRowToAccount(SqlRowSet aRow) {
		Accounts anAcct = new Accounts();
		
		anAcct.setBalance(aRow.getDouble("balance"));
		anAcct.setId(aRow.getLong("account_id"));
		anAcct.setUserId(aRow.getLong("user_id"));
		
		return anAcct;
	}

}
