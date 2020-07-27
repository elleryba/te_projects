//package com.techelevator;
//
//import java.sql.Connection;
//import java.sql.SQLException;
//import java.sql.Statement;
//import java.time.LocalDate;
//import java.util.List;
//import java.util.Scanner;
//
//import org.apache.commons.dbcp2.BasicDataSource;
//
//import com.techelevator.model.campground.CampgroundDAO;
//import com.techelevator.model.campground.JdbcCampgroundDAO;
//import com.techelevator.model.park.JdbcParkDAO;
//import com.techelevator.model.park.Park;
//import com.techelevator.model.park.ParkDAO;
//import com.techelevator.model.reservation.*;
//import com.techelevator.model.site.JdbcSiteDAO;
//import com.techelevator.model.site.SiteDAO;
//import com.techelevator.view.*;
//
//public class CampgroundApp {
//	
//	/****************************************************************************************************
//	 * This is the Campground Reservation system application program
//	 * 
//	 * Any and all user interactions should be placed in the CampgroundUI class 
//	 *     which is in the com.techelevator.view package.
//	 *     
//	 * This application program should instantiate a CampgroundUI object 
//	 *      and use its methods to interact with the user.
//	 *      
//	 * This application program should contain no user interactions.
//	 * 
//	 * Any and all database accesses should be placed in the appropriate
//	 *     com.techelevator.model.tablename package component
//	 *     
//	 * This application program should instantiate DAO objects and use the methods
//	 *     in the DAO to interact with the database tables.   
//	 *     
//	 * There should be no SQL in this application program
//	 *   
//	 ***************************************************************************************************/
//	
//	public static void main(String[] args) {
//		
//		BasicDataSource dataSource = new BasicDataSource();
//		dataSource.setUrl("jdbc:postgresql://localhost:5432/campground");
//		dataSource.setUsername("postgres");
//		dataSource.setPassword("postgres1");
//
//		
//		  // Object to manage user interactions;
//		                                                  // Feel free to change the name
//		
//		/****************************************************************************************************
//		 * Instantiate any DAOs you will be using here
//		 ***************************************************************************************************/
//		
//		ParkDAO parkDAO = new JdbcParkDAO(dataSource);
//		CampgroundDAO campDAO = new JdbcCampgroundDAO(dataSource);
//		SiteDAO siteDAO = new JdbcSiteDAO(dataSource);
//		ReservationDAO resDAO = new JdbcReservationDAO(dataSource);
//		
//		
//		
//		
//		
//		/****************************************************************************************************
//		 * Your application programming logic goes here
//		 ***************************************************************************************************/
//		CampgroundUI userInterface = new CampgroundUI(dataSource);
//		userInterface.run();
//		
//	}
//}
