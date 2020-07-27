package com.techelevator;

import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertTrue;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNull;

import java.sql.SQLException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.datasource.SingleConnectionDataSource;

import com.techelevator.model.campground.Campground;
import com.techelevator.model.campground.JdbcCampgroundDAO;
import com.techelevator.model.park.JdbcParkDAO;
import com.techelevator.model.park.Park;
import com.techelevator.model.reservation.JdbcReservationDAO;
import com.techelevator.model.reservation.Reservation;
import com.techelevator.model.site.JdbcSiteDAO;
import com.techelevator.model.site.Site;

public class DAOIntegrationTest {

	/* Using this particular implementation of DataSource so that
	 * every database interaction is part of the same database
	 * session and hence the same database transaction */
	private static SingleConnectionDataSource dataSource;
	
	//Setting up a test date to use across tables
	private static final LocalDate TEST_DATE = LocalDate.now();
	
	//Setting up Campground data
	private long testCampId;
	private static final String TEST_CAMP_NAME = "Test Camp";
	private static final String TEST_OPEN_FROM_MM = "10";
	private static final String TEST_OPEN_TO_MM = "12";
	
	private JdbcCampgroundDAO campgroundDao;
	
	//Setting up Park data
	private long testParkId;
	private static final String TEST_PARK_NAME = "Test Park";
	private static final String TEST_PARK_LOCATION = "Not There";
	private static final int TEST_AREA = 1234;
	private static final int TEST_VISITORS = 4321;
	private static final String TEST_DESC = "This is a test park";
	
	private JdbcParkDAO parkDao;
	
	//Setting up Site data
	private long testSiteId;
	private static final int TEST_SITE_NUMBER = 5678;
	private static final int TEST_MAX_OCC = 8765;
	private static final boolean TEST_ACCESSIBLE = true;
	private static final int TEST_MAX_RV_LENGTH = 2020;
	private static final boolean TEST_UTILS = true;

	private JdbcSiteDAO siteDao;
	
	//Setting up Reservation data
	private long testResId;
	private static long setResId = 9999;
	private static final String TEST_RES_NAME = "Test Reservation Name";
	private static final LocalDate TEST_FROM_DATE = LocalDate.of(2021, 01, 01);
	private static final LocalDate TEST_TO_DATE = LocalDate.of(2021, 01, 15);

	private JdbcReservationDAO resDao;

	/* Before any tests are run, this method initializes the datasource for testing. */
	@BeforeClass
	public static void setupDataSource() {
		dataSource = new SingleConnectionDataSource();
		dataSource.setUrl("jdbc:postgresql://localhost:5432/campground");
		dataSource.setUsername("postgres");
		dataSource.setPassword("postgres1");
		/* The following line disables autocommit for connections
		 * returned by this DataSource. This allows us to rollback
		 * any changes after each test */
		dataSource.setAutoCommit(false);
	}

	/* After all tests have finished running, this method will close the DataSource */
	@AfterClass
	public static void closeDataSource() throws SQLException {
		dataSource.destroy();
	}

	/* After each test, we rollback any changes that were made to the database so that
	 * everything is clean for the next test */
	@After
	public void rollback() throws SQLException {
		dataSource.getConnection().rollback();
	}
	
	@Before
	public void setup() {
		
		JdbcTemplate jdbcTemplate = new JdbcTemplate(dataSource);
		
		/*
		 * Creating a test Park
		 */
		String createParkSql = "INSERT INTO park (name, location, establish_date, "
				+ "area, visitors, description) VALUES (?, ?, ?, ?, ?, ?) RETURNING park_id;";
		testParkId = jdbcTemplate.queryForObject(createParkSql, Long.class, TEST_PARK_NAME, TEST_PARK_LOCATION, 
				TEST_DATE, TEST_AREA, TEST_VISITORS, TEST_DESC);
		
		parkDao = new JdbcParkDAO(dataSource);
		
		/*
		 * Creating a Test Campground
		 */
		String createCampSql = "INSERT INTO campground (park_id, name, "
				+ "open_from_mm, open_to_mm, daily_fee) VALUES(?, ?, ?, ?, '10.00'::numeric::money) "
				+ "RETURNING campground_id;";
		testCampId = jdbcTemplate.queryForObject(createCampSql, Long.class, testParkId, TEST_CAMP_NAME, 
				TEST_OPEN_FROM_MM, TEST_OPEN_TO_MM);
		
		campgroundDao = new JdbcCampgroundDAO(dataSource);
		
		/*
		 * Creating a test Site
		 */
		String createSiteSql = "INSERT INTO site (campground_id, site_number, max_occupancy, "
				+ "accessible, max_rv_length, utilities) VALUES (?, ?, ?, ?, ?, ?) "
				+ "RETURNING site_id";
		testSiteId = jdbcTemplate.queryForObject(createSiteSql, Long.class, testCampId, TEST_SITE_NUMBER, 
				TEST_MAX_OCC, TEST_ACCESSIBLE, TEST_MAX_RV_LENGTH, TEST_UTILS);
		
		siteDao = new JdbcSiteDAO(dataSource);
		
		/*
		 * Creating a test Reservation
		 */
		String createResSql = "INSERT INTO reservation (site_id, name, from_date, to_date, create_date) "
				+ "VALUES (?, ?, ?, ?, ?) RETURNING reservation_id;";
		
		testResId = jdbcTemplate.queryForObject(createResSql, Long.class, testSiteId, TEST_RES_NAME, 
				TEST_DATE, TEST_DATE, TEST_DATE);
		
		resDao = new JdbcReservationDAO(dataSource);
		
	}

	/* This method provides access to the DataSource for subclasses so that
	 * they can instantiate a DAO for testing */
	protected DataSource getDataSource() {
		return dataSource;
	}

//	@Test
//	public void test_get_campground_by_park_name() {
//		
//		List<Campground> theCamps = campgroundDao.getCampgroundByParkName(TEST_PARK_NAME);
//		
//		assertNotNull(theCamps);
//		assertTrue(theCamps.size() >= 1);
//		assertEquals(TEST_CAMP_NAME, theCamps.get(0).getName());
//	}
//	
//	@Test
//	public void test_get_campground_by_id() {
//		
//		List<Campground> theCamps = campgroundDao.getCampgroundById(testCampId);
//		
//		assertNotNull(theCamps);
//		assertTrue(theCamps.size() >= 1);
//		assertEquals(TEST_CAMP_NAME, theCamps.get(0).getName());
//		
//	}
//	
	@Test
	public void test_get_campground_by_park_id() {
		
		List<Campground> theCamps = campgroundDao.getCampgroundsByParkId(testParkId);
		
		assertNotNull(theCamps);
		assertTrue(theCamps.size() >= 1);
		assertEquals(TEST_CAMP_NAME, theCamps.get(0).getName());
	}
	
	@Test
	public void test_get_all_parks() {
		
		List<Park> theParks = parkDao.getAllParks();
		
		assertNotNull(theParks);
		assertTrue(theParks.size() >= 1);
	}
	
//	@Test
//	public void test_get_park_by_id() {
//		
//		List<Park> theParks = parkDao.getParkById(testParkId);
//		
//		assertNotNull(theParks);
//		assertTrue(theParks.size() >= 1);
//		assertEquals(TEST_PARK_NAME, theParks.get(0).getName());
//	}
//	
//	@Test
//	public void test_get_park_by_name() {
//		
//		List<Park> theParks = parkDao.getParkByName(TEST_PARK_NAME);
//		
//		assertNotNull(theParks);
//		assertTrue(theParks.size() >= 1);
//		assertEquals(TEST_PARK_NAME, theParks.get(0).getName());
//	}

//	@Test
//	public void test_make_reservation() {
//		
//		List<Reservation> newReservation = new ArrayList<Reservation>();
//				
//		resDao.makeNewReservation(testSiteId, TEST_RES_NAME, TEST_FROM_DATE, 
//				TEST_TO_DATE);
//		
////		long newResId = resDao.makeReservation(testSiteId, TEST_RES_NAME, TEST_DATE, TEST_DATE);
////		
////		Reservation newTestRes = resDao.getReservationByReservationId(newResId);
////		Reservation theRes = resDao.getReservationByReservationId();
//		
//		assertNotNull(newReservation);
//		//assertEquals(TEST_RES_NAME, theRes.getName());
//	}
	
	@Test
	public void test_get_latest_res_id() {
	
		Long latestReservation = resDao.getLatestResId();
		
		assertNotNull(latestReservation);
	}
	
	@Test
	public void test_get_available_sites() {
		
		List<Site> availableSites = siteDao.getAvailableSites(1L, TEST_FROM_DATE, TEST_TO_DATE);
		
		assertNotNull(availableSites);
		assertTrue(availableSites.size() >= 1);
	}
	
//	@Test
//	//InvalidResultSetAccessException: Invalid column name
//	public void test_get_site_by_id() {
//		
//		assertNotNull(siteDao.getCampsiteWithSiteId(testSiteId));
//	}
	
	@Test
	public void test_get_total_bill() {
		
		assertNotNull(siteDao.getTotalBill(testCampId, TEST_FROM_DATE, TEST_TO_DATE));
		assertEquals(140.0, siteDao.getTotalBill(testCampId, TEST_FROM_DATE, TEST_TO_DATE), .000001);
	}
}
