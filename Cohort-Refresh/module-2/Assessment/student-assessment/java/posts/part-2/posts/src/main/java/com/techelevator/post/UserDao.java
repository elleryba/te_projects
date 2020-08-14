package com.techelevator.post;

import java.util.List;

public interface UserDao {

	public void save(User newUser);

	public List<User> getAllUsers();
}
