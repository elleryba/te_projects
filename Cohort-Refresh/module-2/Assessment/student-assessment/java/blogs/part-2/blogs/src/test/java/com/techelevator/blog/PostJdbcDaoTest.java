package com.techelevator.blog;

import static org.junit.Assert.assertEquals;
import java.sql.SQLException;
import java.time.LocalDate;
import java.util.List;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.datasource.SingleConnectionDataSource;
import org.springframework.jdbc.support.rowset.SqlRowSet;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class PostJdbcDaoTest {

	private static SingleConnectionDataSource dataSource;
	private PostJdbcDao dao;
	private JdbcTemplate template;

	@BeforeClass
	public static void setupDataSource() {
		dataSource = new SingleConnectionDataSource();
		dataSource.setUrl("jdbc:postgresql://localhost:5432/assessment");
		dataSource.setUsername("postgres");
		dataSource.setPassword("postgres1");
		/* The following line disables autocommit for connections
		 * returned by this DataSource. This allows us to rollback
		 * any changes after each test */
		dataSource.setAutoCommit(false);
	}

	/* After all tests have finished running, this method will close the DataSource */
	@AfterClass
	public static void closeDataSource() throws SQLException {
		dataSource.destroy();
	}

	@Before
	public void setup() {
		dao = new PostJdbcDao(dataSource);
		template = new JdbcTemplate(dataSource);
	}

	/* After each test, we rollback any changes that were made to the database so that
	 * everything is clean for the next test */
	@After
	public void rollback() throws SQLException {
		dataSource.getConnection().rollback();
	}

	@Test
	public void testSaveNewPostAddsARow() throws SQLException {
		long beforeCount = getCountFromDatabase();
		Post savedPost = new Post("TESTNAME", "TESTCOOKIE", true, LocalDate.ofEpochDay(101));

		dao.save(savedPost);

		assertEquals("It doesn't look like the post passed to save() was actually saved in the database.", beforeCount + 1, getCountFromDatabase());
	}

	@Test
	public void testAllCartDataSaved() throws SQLException {
		Post savedPost = new Post("TESTNAME", "TESTCOOKIE", true, LocalDate.ofEpochDay(101));

		dao.save(savedPost);

		SqlRowSet result = template.queryForRowSet("select * from posts where id=(select max(id) from posts)");
		if(result.next()) {
			assertEquals("The name was not properly set in the Post on save()", savedPost.getName(), result.getString("name"));
			assertEquals("The body was not properly set in the Post on save()", savedPost.getBody(), result.getString("body"));
			assertEquals("published was not properly set in the Post on save()", savedPost.isPublished(), result.getBoolean("published"));
			assertEquals("created was not properly set in the Post on save()", savedPost.getCreated(),result.getDate("created").toLocalDate());
		}
	}

	@Test
	public void testGetAllPosts() {
		List<Post> allCarts = dao.getAllPosts();

		assertEquals("There should be 200 entries in the database, but I only got back " + allCarts.size(), 200, allCarts.size());
	}

	@Test
	public void testGetCartDetailsInAllCarts() {
		template.update("DELETE FROM posts");

		dao.save(new Post("TESTNAME", "TESTCOOKIE", true, LocalDate.ofEpochDay(101)));
		dao.save(new Post("TESTNAME2", "TESTCOOKIE2", false, LocalDate.ofEpochDay(102)));
		dao.save(new Post("TESTNAME3", "TESTCOOKIE3", true, LocalDate.ofEpochDay(103)));

		List<Post> allCarts = dao.getAllPosts();

		Post second = allCarts.get(1);

		assertEquals("The name was not properly set in the Post on getAllPosts()", "TESTNAME2", second.getName());
		assertEquals("The body was not properly set in the Post on getAllPosts()", "TESTCOOKIE2", second.getBody());
		assertEquals("published was not properly set in the Post on getAllPosts()", false, second.isPublished());
		assertEquals("created was not properly set in the Post on getAllPosts()", LocalDate.ofEpochDay(102), second.getCreated());
	}

	private long getCountFromDatabase() {
		return template.queryForObject("select count(*) from posts", Long.class);
	}
}
