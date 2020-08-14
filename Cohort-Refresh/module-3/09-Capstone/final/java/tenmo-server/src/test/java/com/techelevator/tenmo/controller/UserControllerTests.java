package com.techelevator.tenmo.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.techelevator.tenmo.dao.UserDAO;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.test.context.support.WithMockUser;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.test.web.servlet.RequestBuilder;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;

import java.security.Principal;

import static org.junit.jupiter.api.Assertions.assertEquals;

@WebMvcTest(controllers = UserController.class)
@AutoConfigureMockMvc
public class UserControllerTests {

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    private ObjectMapper objectMapper;

    @MockBean
    private UserDAO userDAO;

    @BeforeAll
    public static void setUp() {
        SecurityContextHolder.clearContext();
    }

//    @Test
//    @WithMockUser
//    void whenUserIsAuthenticated_ListReturnsUsers() throws Exception {
//        // Arrange
//        RequestBuilder requestBuilder = MockMvcRequestBuilders
//                .get("/users")
//                .accept(MediaType.APPLICATION_JSON);
//
//        // Act
//        MvcResult result = mockMvc.perform(requestBuilder).andReturn();
//        MockHttpServletResponse response = result.getResponse();
//        int status = response.getStatus();
//
//        // Assert
//        assertEquals(200,status,"Response status is not OK");
//    }

}
