package com.techelevator.tenmo.services;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.MediaType;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestClientResponseException;
import org.springframework.web.client.RestTemplate;

import com.techelevator.tenmo.models.Transfer;
import com.techelevator.tenmo.models.TransferCredentials;
import com.techelevator.tenmo.models.TransferDTO;

public class TransferService {

	private String BASE_SERV_URL;
	private RestTemplate restTemplate = new RestTemplate();


	public TransferService(String url) { // The server URL will be passed in as a parameter
		this.BASE_SERV_URL = url + "transfers/";
	}


	public void addTrans(String authToken, TransferDTO creds) {
		try {
			restTemplate.exchange(BASE_SERV_URL, HttpMethod.POST, makeTransDTOEntity(authToken, creds), TransferDTO.class);
		}
		catch(RestClientResponseException e) {
			System.out.println(e.getMessage());
		}
	}
	
	//the method below allows an authenticated user to search for Transfers by their ID
	//this method works server-side, but there was no clear place to implement this
	//	method in the App for the user to interact with
	public Transfer[] getById(String authToken, long id) {
		Transfer[] theTrans = null;

		try {
			theTrans = restTemplate.exchange(BASE_SERV_URL + id, HttpMethod.GET, makeAuthEntity(authToken), Transfer[].class).getBody();
		}
		catch(RestClientException e) {
			System.out.println(e.getMessage());
		}
		return theTrans;
	}

	private HttpEntity<TransferDTO> makeTransDTOEntity(String authToken, TransferDTO creds) {
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		headers.setBearerAuth(authToken);
		HttpEntity<TransferDTO> entity = new HttpEntity<>(creds, headers);
		return entity;
	}

	private HttpEntity makeAuthEntity(String authToken) {
		HttpHeaders headers = new HttpHeaders();
		headers.setBearerAuth(authToken); // Must add Bearer header with the JWT
		HttpEntity entity = new HttpEntity<>(headers);
		return entity;
	}

}
