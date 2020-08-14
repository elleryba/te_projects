package com.techelevator.blog;

import java.util.List;

public interface PostDao {

	public void save(Post newPost);

	public List<Post> getAllPosts();

}
