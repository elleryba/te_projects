package com.techelevator.tenmo.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.techelevator.tenmo.dao.AccountDAO;
import org.assertj.core.api.Assert;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.test.web.servlet.RequestBuilder;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;

import java.security.Principal;

@WebMvcTest(controllers = AccountController.class)
public class AccountControllerTests {

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    private ObjectMapper objectMapper;

    @MockBean
    private AccountDAO accountDAO;

    @Test
    void whenUserIsLoggedIn_getCurrentAccountBalance() throws Exception {
        // Arrange
        Principal mockPrincipal = Mockito.mock(Principal.class);
        Mockito.when(mockPrincipal.getName()).thenReturn("user");

        RequestBuilder requestBuilder = MockMvcRequestBuilders
                .get("/account/balance")
                .principal(mockPrincipal)
                .accept(MediaType.APPLICATION_JSON);

        // Act
        MvcResult result = mockMvc.perform(requestBuilder).andReturn();
        MockHttpServletResponse response = result.getResponse();
        int status = response.getStatus();

        // Assert
        Assertions.assertEquals(200, status,"Response status code is wrong");
    }

}
