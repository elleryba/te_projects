package com.techelevator.model;

public class Beer {
	
	private Long beerid;
	private String name;
	private String image;
	private String description;
	private String abv;
	private Long type;
	
	@Override
	public String toString() {
		return "Beer beerid = " + beerid + ", name = " + name + ", image = " + image + ", description = " + description
				+ ", abv = " + abv + ", type = " + type;
	}
	
	public Beer(Long beerid, String name, String image, String description, String abv, Long type) {
		
		this.beerid = beerid;
		this.name = name;
		this.image = image;
		this.description = description;
		this.abv = abv;
		this.type = type;
	}
	
	public Beer(String name, String image, String description, String abv, Long type) {
		
		this.beerid = 99L;
		this.name = name;
		this.image = image;
		this.description = description;
		this.abv = abv;
		this.type = type;
	}
	public Beer() {}
	
	public Beer(Beer beer) {
		
		this.beerid = beer.beerid;
		this.name = beer.name;
		this.image = beer.image;
		this.description = beer.description;
		this.abv = beer.abv;
		this.type = beer.type;
	}

	public Long getBeerid() {
		return beerid;
	}

	public void setBeerid(Long beerid) {
		this.beerid = beerid;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getAbv() {
		return abv;
	}

	public void setAbv(String abv) {
		this.abv = abv;
	}

	public Long getType() {
		return type;
	}

	public void setType(Long type) {
		this.type = type;
	}
	
	
	
	

}
