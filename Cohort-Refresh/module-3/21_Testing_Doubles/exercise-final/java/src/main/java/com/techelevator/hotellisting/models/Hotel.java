package com.techelevator.hotellisting.models;

import javax.validation.Valid;
import javax.validation.constraints.*;
import java.math.BigDecimal;

public class Hotel {

    private String id;
    @NotBlank(message = "Please enter a name")
    private String name;
    @Valid
    private Address address;
    private int rating;
    @Min(value = 0, message = "Please enter a positive number of rooms available.")
    private int roomsAvailable;
    @DecimalMin(value = "1.0", message = "Please enter a number greater than 0 for cost per night.")
    private BigDecimal costPerNight;
    private String coverImage;

    public Hotel(String id, String name, Address address, int rating, int numberOfRooms, double costPerNight,
            String cover) {
        this.id = id;
        this.name = name;
        this.address = address;
        this.rating = rating;
        this.roomsAvailable = numberOfRooms;
        this.costPerNight = new BigDecimal(costPerNight);
        this.coverImage = cover;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public int getRoomsAvailable() {
        return roomsAvailable;
    }

    public void setRoomsAvailable(int roomsAvailable) {
        this.roomsAvailable = roomsAvailable;
    }

    public BigDecimal getCostPerNight() {
        return costPerNight;
    }

    public void setCostPerNight(BigDecimal costPerNight) {
        this.costPerNight = costPerNight;
    }

    public String getCoverImage() {
        return coverImage;
    }

    public void setCoverImage(String coverImage) {
        this.coverImage = coverImage;
    }

    @Override
    public String toString() {
        return "Hotel{" + "id=" + id + ", name='" + name + '\'' + '}';
    }

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((address == null) ? 0 : address.hashCode());
        result = prime * result
                + ((costPerNight == null) ? 0 : costPerNight.hashCode());
        result = prime * result
                + ((coverImage == null) ? 0 : coverImage.hashCode());
        result = prime * result + ((id == null) ? 0 : id.hashCode());
        result = prime * result + ((name == null) ? 0 : name.hashCode());
        result = prime * result + rating;
        result = prime * result + roomsAvailable;
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        Hotel other = (Hotel) obj;
        if (address == null) {
            if (other.address != null)
                return false;
        } else if (!address.equals(other.address))
            return false;
        if (costPerNight == null) {
            if (other.costPerNight != null)
                return false;
        } else if (!costPerNight.equals(other.costPerNight))
            return false;
        if (coverImage == null) {
            if (other.coverImage != null)
                return false;
        } else if (!coverImage.equals(other.coverImage))
            return false;
        if (id == null) {
            if (other.id != null)
                return false;
        } else if (!id.equals(other.id))
            return false;
        if (name == null) {
            if (other.name != null)
                return false;
        } else if (!name.equals(other.name))
            return false;
        if (rating != other.rating)
            return false;
        if (roomsAvailable != other.roomsAvailable)
            return false;
        return true;
    }
}
