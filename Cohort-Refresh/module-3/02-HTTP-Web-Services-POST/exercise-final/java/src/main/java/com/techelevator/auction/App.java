package com.techelevator.auction;

import org.springframework.web.client.ResourceAccessException;
import org.springframework.web.client.RestClientResponseException;

import com.techelevator.models.Auction;
import com.techelevator.services.AuctionService;
import com.techelevator.services.ConsoleService;

public class App {

    public static void main(String[] args) {
        int menuSelection;
        int auctionId = -1;

        ConsoleService consoleService = new ConsoleService();
        AuctionService auctionService = new AuctionService("http://localhost:3000/auctions");

        while (true) {
            menuSelection = consoleService.printMainMenu();
            if (menuSelection == 1) {
            	Auction[] auctions = auctionService.getAll();
            	if (auctions != null) {
                    consoleService.printAuctions(auctions);
            	}
            } else if (menuSelection == 2) {
            	Auction[] auctions = auctionService.getAll();
                if (auctions != null) {
                    auctionId = consoleService.promptForAuction(auctions, "View");
                    if (auctionId != 0) {
                    	Auction auction = auctionService.getOne(auctionId);
                    	if (auction != null) {
                            consoleService.printAuction(auctionService.getOne(auctionId));
                    	}
                    }
                }
            } else if (menuSelection == 3) {
                String title = consoleService.promptForAuctionTitle();
                if (title != null) {
                	Auction[] auctions = auctionService.getByTitle(title);
                	if (auctions != null) {
                        consoleService.printAuctions(auctions);
                	}
                }
            } else if (menuSelection == 4) {
                double price = consoleService.promptForAuctionPrice();
                if (price != 0.0) {
                	Auction[] auctions = auctionService.getByPrice(price);
                	if (auctions != null) {
                        consoleService.printAuctions(auctions);
                	}
                }
            } else if (menuSelection == 5) { // Add auction
                String newAuctionString = consoleService.promptForAuctionData();
                Auction auction = auctionService.add(newAuctionString);
                // if unsuccessful
                if (auction == null) {
                    System.out.println("Invalid auction. Please enter the Title, Description, User, Current Bid Price (no dollar sign).");
                } else {
                    // Print all auctions every time - provides confirmation of action
                	Auction[] auctions = auctionService.getAll();
                	if (auctions != null) {
                        consoleService.printAuctions(auctions);
                	}
                }
            } else if (menuSelection == 6) { // Update location
            	Auction[] auctions = auctionService.getAll();
            	if (auctions != null) {
                    auctionId = consoleService.promptForAuction(auctions, "Update");
                    Auction auction = auctionService.getOne(auctionId);
                    if (auction != null) {
                        String CSV = consoleService.promptForAuctionData(auction);
                        auction = auctionService.update(CSV);
                        // if unsuccessful
                        if (auction == null) {
                            System.out.println("Invalid auction. Please enter the Title, Description, User, Current Bid Price (no dollar sign).");
                        } else {
                            // Print all locations every time - provides confirmation of action
                        	auctions = auctionService.getAll();
                        	if (auctions != null) {
                                consoleService.printAuctions(auctions);
                        	}
                        }
                    }
            	}
            } else if (menuSelection == 7) { // Delete location
            	Auction[] auctions = auctionService.getAll();
            	if (auctions != null) {
                    auctionId = consoleService.promptForAuction(auctions, "Delete");
                    try {
                        auctionService.delete(auctionId);
                        // Print all locations every time - provides confirmation of action
                        consoleService.printAuctions(auctionService.getAll());
                    } catch (RestClientResponseException ex) {
                        consoleService.printError("Auction may not have been deleted. Please try again.");
                    } catch (ResourceAccessException ex) {
                        consoleService.printError("A network error occurred.");
                    }
            	}
            } else if (menuSelection == 0) { // Exit
                consoleService.exit();
            } else { // defensive programming: anything else is not valid
                System.out.println("Invalid Selection");
            }
            // Press any key to continue...
            if (auctionId != 0) {
                consoleService.next();
            }
        }
    }
}
