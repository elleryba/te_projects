package com.techelevator.hotellisting.controllers;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import java.util.ArrayList;
import java.util.List;
import com.techelevator.hotellisting.dao.ReviewDao;
import com.techelevator.hotellisting.exceptions.ReviewNotFoundException;
import com.techelevator.hotellisting.models.Review;
import com.techelevator.hotellisting.service.EmailNotificationService;
import com.techelevator.hotellisting.service.SmsNotificationService;
import org.junit.Before;
import org.junit.Test;

public class ReviewControllerTest {

    private ReviewController controllerUnderTest;
    private ReviewDao mockDao;
    private EmailNotificationService mockEmailService;
    private SmsNotificationService mockSmsService;

    @Before
    public void createMocksAndController() {
        mockDao = mock(ReviewDao.class);
        mockEmailService = mock(EmailNotificationService.class);
        mockSmsService = mock(SmsNotificationService.class);

        controllerUnderTest =
                new ReviewController(mockDao, mockEmailService, mockSmsService);
    }

    @Test
    public void testListWithReviews() {
        // Arrange
        when(mockDao.getAllForHotel("ABC123")).thenReturn(createTestReviews());

        // Act
        List<Review> returnedReviews = controllerUnderTest.list("ABC123");

        // Assert
        // Review needs an equal method for this to work!
        assertEquals("Returned reviews should be the reviews from the dao",
                createTestReviews(), returnedReviews);
    }

    @Test
    public void testListWithNoReviews() {
        // Arrange
        when(mockDao.getAllForHotel("ABC123")).thenReturn(new ArrayList<>());

        // Act
        List<Review> returnedReviews = controllerUnderTest.list("ABC123");

        // Assert
        assertNotNull("Hotel with no reviews should return a valid list",
                returnedReviews);
        assertEquals("Hotel with no reviews should return empty list", 0,
                returnedReviews.size());
    }

    @Test
    public void testUpdateShouldSetIds() throws ReviewNotFoundException {
        // Arrange
        Review testReview = new Review();
        // No need to mock the method because it doesn't return anything

        // Act
        controllerUnderTest.update(testReview, "ABC123", "DEF456");

        // Assert
        assertEquals("Update should set the Review ID", "DEF456", testReview.getId());
        assertEquals("Update should set the Hotel ID", "ABC123", testReview.getHotelID());
    }

    @Test
    public void testUpdateCallsDao() throws ReviewNotFoundException {
        // Arrange
        Review testReview = new Review();
        // No need to mock the method because it doesn't return anything

        // Act
        controllerUnderTest.update(testReview, "ABC123", "DEF456");

        // Assert
        verify(mockDao).update(testReview);
    }

    @Test
    public void testDeleteCallsDao() {
        // Act
        controllerUnderTest.delete("ABC123");

        // Assert
        verify(mockDao).delete("ABC123");
    }

    @Test
    public void testAddCallsDao() {
        // Arrange
        Review testReview = new Review();

        // Act
        controllerUnderTest.add(testReview, "ABC123");

        // Assert
        verify(mockDao).create(testReview);
    }

    @Test
    public void testAddSetsHotelId() {
        // Arrange
        Review testReview = new Review();

        // Act
        controllerUnderTest.add(testReview, "ABC123");

        // Assert
        assertEquals("Should set the hotel id", "ABC123", testReview.getHotelID());
    }

    @Test
    public void testAddSendsSmsIfStarsIsOne() {
        // Arrange
        Review testReview = new Review();
        testReview.setStars(1);

        // Act
        controllerUnderTest.add(testReview, "ABC123");

        // Assert
        verify(mockSmsService).send(testReview);
    }

    @Test
    public void testAddSendsEmailIfStarsIsFive() {
        // Arrange
        Review testReview = new Review();
        testReview.setStars(5);

        // Act
        controllerUnderTest.add(testReview, "ABC123");

        // Assert
        verify(mockEmailService).send(testReview);
    }

    private List<Review> createTestReviews() {
        List<Review> reviews = new ArrayList<>();
        reviews.add(new Review("DEF456", "ABC123", "TEST ONE", "TEST REVIEW",
                "TEST AUTHOR", 1));
        reviews.add(new Review("GHI789", "ABC123", "TEST ONE", "TEST REVIEW",
                "TEST AUTHOR", 2));
        reviews.add(new Review("JKL123", "ABC123", "TEST ONE", "TEST REVIEW",
                "TEST AUTHOR", 3));
        reviews.add(new Review("MNO456", "ABC123", "TEST ONE", "TEST REVIEW",
                "TEST AUTHOR", 4));
        reviews.add(new Review("PQR789", "ABC123", "TEST ONE", "TEST REVIEW",
                "TEST AUTHOR", 5));
        return reviews;
    }
}
