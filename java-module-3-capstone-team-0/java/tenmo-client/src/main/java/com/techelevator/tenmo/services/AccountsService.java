package com.techelevator.tenmo.services;

import java.util.Map;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestClientResponseException;
import org.springframework.web.client.RestTemplate;

import com.techelevator.tenmo.models.Transfer;
import com.techelevator.tenmo.models.TransferCredentials;
import com.techelevator.tenmo.models.UserCredentials;

public class AccountsService {
	
	private String BASE_SERV_URL;
    private RestTemplate restTemplate = new RestTemplate();

    
    public AccountsService(String url) { // The server URL will be passed in as a parameter
        this.BASE_SERV_URL = url + "account/";
      }
    
    public Double getBalance(String authToken) {
    	Double bal = null;
    	try {
    		bal = restTemplate.exchange(BASE_SERV_URL + "balance", HttpMethod.GET, makeAuthEntity(authToken), Double.class).getBody();
    	}
    	catch(RestClientResponseException e) {
    		
    	}
    	return bal;
    }
    
    public void makeTransfer(String authToken, TransferCredentials creds) {
    	try {
    		restTemplate.exchange(BASE_SERV_URL + "transfer", HttpMethod.PUT, makeTransCredEntity(authToken, creds), TransferCredentials.class);
    	}
    	
    	catch(RestClientResponseException e) {
    		System.out.println(e.getMessage());
    	}
    }
    
	public Transfer[] getTransLog(String authToken) {
		Transfer[] theTrans = null;

		try {
			theTrans = restTemplate.exchange(BASE_SERV_URL + "log", HttpMethod.GET, makeAuthEntity(authToken), Transfer[].class).getBody();
		}
		catch(RestClientException e) {
			System.out.println(e.getMessage());
		}
		return theTrans;
	}
    
    /**
     * Returns an {HttpEntity} with the `Authorization: Bearer:` header
     * 
     * @return {HttpEntity}
     */
    private HttpEntity makeAuthEntity(String authToken) {
      HttpHeaders headers = new HttpHeaders();
      headers.setBearerAuth(authToken); // Must add Bearer header with the JWT
      HttpEntity entity = new HttpEntity<>(headers);
      return entity;
    }
    
	private HttpEntity<TransferCredentials> makeTransCredEntity(String authToken, TransferCredentials creds) {
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		headers.setBearerAuth(authToken);
		HttpEntity<TransferCredentials> entity = new HttpEntity<>(creds, headers);
		return entity;
	}
}
