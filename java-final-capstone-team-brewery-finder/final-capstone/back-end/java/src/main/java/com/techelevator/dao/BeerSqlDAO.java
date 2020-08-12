package com.techelevator.dao;

import java.util.ArrayList;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Service;

import com.techelevator.model.Beer;
import com.techelevator.model.BeerDTO;
import com.techelevator.model.Brewery;

@Service
public class BeerSqlDAO implements BeerDAO {
	
private JdbcTemplate jdbcTemplate;
	
	public BeerSqlDAO(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }
	
	@Override 
	public List<Beer> getAllBeerByBreweryName(String name) {
		
		  List<Beer> beers = new ArrayList<Beer>(); 
		  String beerSql = "SELECT * FROM beers b INNER JOIN beerbrewery bb ON bb.beerid = b.beerid INNER JOIN breweries brew ON bb.breweryid = brew.id WHERE brew.brewery_name = ?;";
		  
		  SqlRowSet beerSet = jdbcTemplate.queryForRowSet(beerSql, name);
		  
		  while(beerSet.next()) { 
			  Beer aBeer = MapRowToBeer(beerSet);
			  beers.add(aBeer);
			  
		  } 
		  
		  return beers; }
	
	
	@Override
	public void addABeerToBrewery(BeerDTO beerDto) {
		
		String getBreweryIdSql = "Select id from breweries where brewery_name = ? ";
		
		Long anId = 0L;
		Long beerId = 0L;
		
		SqlRowSet idSet = jdbcTemplate.queryForRowSet(getBreweryIdSql, beerDto.getBreweryName());
		
		while (idSet.next()) {
			anId = idSet.getLong("id");
		}
		
		String doesNameExist = "SELECT beerid from beers where name = ?";
		String doesNameExist2 ="INSERT INTO beerbrewery (breweryid, beerid) VALUES (?, ?)";
		
		SqlRowSet beerIdSet = jdbcTemplate.queryForRowSet(doesNameExist, beerDto.getaBeer().getName());
		
		if (beerIdSet.next()) {
			beerId = beerIdSet.getLong("beerid");
			jdbcTemplate.update(doesNameExist2, anId, beerId);
		}
		else {
		String addBeerSql = "INSERT INTO beers (name, image, description, abv, type ) VALUES (?,?,?,?,?);";
		String addBeerSql2 ="INSERT INTO beerbrewery (breweryid, beerid) VALUES (?, (SELECT beerid FROM beers WHERE name = ?))";
		jdbcTemplate.update(addBeerSql, beerDto.getaBeer().getName(), beerDto.getaBeer().getImage(), beerDto.getaBeer().getDescription(), beerDto.getaBeer().getAbv(), beerDto.getaBeer().getType());
		jdbcTemplate.update(addBeerSql2, anId, beerDto.getaBeer().getName());
		}
	}
			//, Integer.parseInt(aBeer.getBeerid().toString())
	
	public void addABeer(Beer aBeer) {
		String addBeerSql = "INSERT INTO beers (name, image, description, abv, type ) VALUES (?,?,?,?,?);";
		jdbcTemplate.update(addBeerSql, aBeer.getName(), aBeer.getImage(), aBeer.getDescription(), aBeer.getAbv(), aBeer.getType());
	}
	
	public void deleteABeer(BeerDTO beerDto) {
		String deleteBeerSql = "DELETE FROM beerbrewery where beerid IN (SELECT beerid FROM beers WHERE name = ?) AND breweryid IN (SELECT breweryid FROM breweries WHERE brewery_name = ?);";
		jdbcTemplate.update(deleteBeerSql, beerDto.getaBeer().getName(), beerDto.getBreweryName());
	}
	
	public Long getBreweryById(String name) {
		String getBreweryIdSql = "Select id from breweries where brewery_name = ? ";
		
		Long anId = 4L;
		
		SqlRowSet idSet = jdbcTemplate.queryForRowSet(getBreweryIdSql, name);
		
		while (idSet.next()) {
			anId = idSet.getLong("id");
		}
		
		return anId;
	}
	
	
	
	
	
	private Beer MapRowToBeer(SqlRowSet aRow) {
		
		Beer aBeer = new Beer();
		
		aBeer.setBeerid(aRow.getLong("beerid"));
		aBeer.setName(aRow.getString("name"));
		aBeer.setImage(aRow.getString("image"));
		aBeer.setDescription(aRow.getString("description"));
		aBeer.setAbv(aRow.getString("abv"));
		aBeer.setType(aRow.getLong("type"));

		return aBeer;
	}

	@Override
	public List<Beer> getAllBeers() {
		
		  List<Beer> beers = new ArrayList<Beer>(); 
		  String beerSql = "SELECT * FROM beers;";
		  
		  SqlRowSet beerSet = jdbcTemplate.queryForRowSet(beerSql);
		  
		  while(beerSet.next()) { 
			  Beer aBeer = MapRowToBeer(beerSet);
			  beers.add(aBeer);
			  
		  } 
		  
		  return beers;
	}

	

}
