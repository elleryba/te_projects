package com.techelevator.tenmo.services;


import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.web.client.RestClientResponseException;
import org.springframework.web.client.RestTemplate;

import com.techelevator.tenmo.models.User;

public class UserService {
	
	private String BASE_USER_URL;
	private RestTemplate restTemplate = new RestTemplate();
	
	public UserService(String url) {
		this.BASE_USER_URL = url + "user/";
	}
	
	public User[] getAllUsers(String authToken){
		User[] theUsers = null;
		
		try {
			theUsers = restTemplate.exchange(BASE_USER_URL + "allusers", HttpMethod.GET, makeAuthEntity(authToken), User[].class).getBody();
		}
		catch(RestClientResponseException e) {
			
		}
		return theUsers;
	}

    private HttpEntity makeAuthEntity(String authToken) {
        HttpHeaders headers = new HttpHeaders();
        headers.setBearerAuth(authToken); // Must add Bearer header with the JWT
        HttpEntity entity = new HttpEntity<>(headers);
        return entity;
      }
}
