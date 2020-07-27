package com.techelevator.tenmo.dao;

import java.util.ArrayList;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Service;

import com.techelevator.tenmo.model.Transfer;
@Service
public class JdbcTransferDAO implements TransferDAO {
	
	private JdbcTemplate jdbcTemplate;
	
	public JdbcTransferDAO(JdbcTemplate jdbcTemplate) {
		this.jdbcTemplate = jdbcTemplate;
	}

	//the method below allows an authenticated user to search for Transfers by their ID
	//this method works server-side, but there was no clear place to implement this
	//	method in the App for the user to interact with
	@Override
	public List<Transfer> getById(Long transId) {
		List<Transfer> theTrans = new ArrayList<Transfer>();
		String transSql = "SELECT * FROM transfers WHERE transfer_id = ?;";
		
		SqlRowSet result = jdbcTemplate.queryForRowSet(transSql, transId);
		
		while(result.next()) {
			Transfer aTrans = MapRowToTransfer(result);
			theTrans.add(aTrans);
		}
		return theTrans;
	}

	@Override
	public void addTrans(Long typeId, Long statusId, Long acctFrom, Long acctTo, Double amount) {
		String newTransSql = "INSERT into transfers (transfer_type_id, transfer_status_id, account_from, account_to, amount) "
				+ "VALUES (?, ?, ?, ?, ?);";
		jdbcTemplate.update(newTransSql, typeId, statusId, acctFrom, acctTo, amount);
	}

	@Override
	public List<Transfer> listTransByAcct(Long acctFrom, Long acctTo) {
		List<Transfer> theTrans = new ArrayList<Transfer>();
		String getTransSql = "SELECT * FROM transfers WHERE account_from = ? OR account_to = ?;";
		
		SqlRowSet result = jdbcTemplate.queryForRowSet(getTransSql, acctFrom, acctTo);
		while(result.next()) {
			Transfer aTrans = MapRowToTransfer(result);
			theTrans.add(aTrans);
		}
		
		return theTrans;
	}
	
	private Transfer MapRowToTransfer(SqlRowSet aRow) {
		Transfer aTrans = new Transfer();
		
		aTrans.setId(aRow.getLong("transfer_id"));
		aTrans.setTypeId(aRow.getLong("transfer_type_id"));
		aTrans.setStatusId(aRow.getLong("transfer_status_id"));
		aTrans.setAcctFrom(aRow.getLong("account_from"));
		aTrans.setAcctTo(aRow.getLong("account_to"));
		aTrans.setAmount(aRow.getDouble("amount"));
		
		return aTrans;
	}

//	@Override
//	public List<Transfer> getAllTrans() {
//		List<Transfer> theTrans = new ArrayList<Transfer>();
//		String transSql = "SELECT * FROM transfers;";
//		
//		SqlRowSet result = jdbcTemplate.queryForRowSet(transSql);
//		
//		while(result.next()) {
//			Transfer aTrans = MapRowToTransfer(result);
//			theTrans.add(aTrans);
//		}
//		return theTrans;
//	}
	
}
