package com.techelevator.blog;

import java.time.LocalDate;

public class Post {
	private Long id;
	private String name;
	private String body;
	private boolean published;
	private LocalDate created;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getBody() {
		return body;
	}

	public void setBody(String body) {
		this.body = body;
	}

	public boolean isPublished() {
		return published;
	}

	public void setPublished(boolean published) {
		this.published = published;
	}

	public LocalDate getCreated() {
		return created;
	}

	public void setCreated(LocalDate created) {
		this.created = created;
	}

	public Post(String name, String body, boolean published,
			LocalDate created) {
		this.name = name;
		this.body = body;
		this.published = published;
		this.created = created;
	}

	public Post() {
	}



}
