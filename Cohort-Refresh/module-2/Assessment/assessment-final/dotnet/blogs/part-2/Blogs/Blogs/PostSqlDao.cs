using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blogs
{
    public class PostSqlDao : IPostDao
    {
        private readonly string connectionString;

        public PostSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Post> GetAllPosts()
        {
            IList<Post> posts = new List<Post>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT id, name, body, published, created FROM posts";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    posts.Add(new Post
                    {
                        Body = reader["body"] as string,
                        Created = (DateTime)reader["created"],
                        Id = (int)reader["id"],
                        IsPublished = (bool)reader["published"],
                        Name = reader["name"] as string
                    });
                }
            }

            return posts;
        }

        public void Save(Post newPost)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO posts (name, body, created, published) VALUES (@name, @body, @created, @published); SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
                command.Parameters.AddWithValue("@name", newPost.Name);
                command.Parameters.AddWithValue("@body", newPost.Body);
                command.Parameters.AddWithValue("@created", newPost.Created);
                command.Parameters.AddWithValue("@published", newPost.IsPublished);

                connection.Open();

                newPost.Id = (long)command.ExecuteScalar();
            }
        }
    }
}