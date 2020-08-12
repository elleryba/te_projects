package com.techelevator.dao;

import java.util.ArrayList;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Service;

import com.techelevator.model.Brewery;
import com.techelevator.model.BreweryDTO;


@Service
public class BrewerySqlDAO implements BreweryDAO {
	
	private JdbcTemplate jdbcTemplate;
	
	public BrewerySqlDAO(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }
	
	
	@Override
	public void addBrewery(BreweryDTO breweryDTO) {
		
		
		String addBrewSql = "INSERT INTO breweries (brewery_name, history, open_from, open_to, days_open, address) VALUES (?,?,?,?,?,?) ";
	
		jdbcTemplate.update(addBrewSql, breweryDTO.getName(), breweryDTO.getHistory(), breweryDTO.getOpenFrom(), breweryDTO.getOpenTo(), breweryDTO.getDaysOpen(), breweryDTO.getAddress());
		
	}
	
	@Override
	public Brewery getBreweryByName(BreweryDTO breweryDTO) {
		
		Brewery aBrew = new Brewery();
		
		String getBrewSql = "SELECT * FROM breweries WHERE name = ?";
		SqlRowSet result = jdbcTemplate.queryForRowSet(getBrewSql, breweryDTO.getName());
		
		while(result.next()) {
			aBrew = MapRowToBrewery(result);
		}
		
		return aBrew;
		
	}
	
	@Override
	public void updateBrewery(Long id,BreweryDTO breweryDTO) {
		
		String updateBrewery = "UPDATE breweries SET brewery_name = ?, "
												+ "  history = ?, "
												+ "  open_from = ?, "
												+ "  open_to = ?, "
												+ "  days_open = ?, "
												+ "  address = ? "
												+ "  WHERE id = ?";
		
		jdbcTemplate.update(updateBrewery, breweryDTO.getName(), breweryDTO.getHistory(), breweryDTO.getOpenFrom(), breweryDTO.getOpenTo(), breweryDTO.getDaysOpen(), breweryDTO.getAddress(), id);
				
	}
	
	// this is for a commit
	
	@Override public List<Brewery> getAllBreweries() {
		
		  List<Brewery> breweries = new ArrayList<Brewery>(); 
		  String breweriesSQL = "Select * From breweries";
		  
		  
		  SqlRowSet brewerySet = jdbcTemplate.queryForRowSet(breweriesSQL);
		  
		  while(brewerySet.next()) { 
			  Brewery aBrewery = MapRowToBrewery(brewerySet);
			  breweries.add(aBrewery);
			  
		  } 
		  
		  return breweries; }
	
	
	
	
	private Brewery MapRowToBrewery(SqlRowSet aRow) {
		Brewery aBrew = new Brewery();
		
		aBrew.setId(aRow.getLong("id"));
		aBrew.setName(aRow.getString("brewery_name"));
		aBrew.setHistory(aRow.getString("history"));
		aBrew.setOpenFrom(aRow.getString("open_from"));
		aBrew.setOpenTo(aRow.getString("open_to"));
		aBrew.setDaysOpen(aRow.getString("days_open"));
		aBrew.setAddress(aRow.getString("address"));
		
		
		return aBrew;
	}
	
}
