using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Posts
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;

        public UserSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT id, first_name, last_name, email, role, created 
                    FROM users";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Created = (DateTime)reader["created"],
                        Email = reader["email"] as string,
                        FirstName = reader["first_name"] as string,
                        Id = (int)reader["id"],
                        LastName = reader["last_name"] as string,
                        Role = reader["role"] as string
                    });
                }
            }

            return users;
        }

        public void Save(User newUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO users (first_name, last_name, email, role, created) 
                    VALUES (@first_name, @last_name, @email, @role, @created); 
                    SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
                command.Parameters.AddWithValue("@created", newUser.Created);
                command.Parameters.AddWithValue("@first_name", newUser.FirstName);    
                command.Parameters.AddWithValue("@last_name", newUser.LastName);
                command.Parameters.AddWithValue("@email", newUser.Email);
                command.Parameters.AddWithValue("@role", newUser.Role);
                
                connection.Open();

                newUser.Id = (long)command.ExecuteScalar();
            }
        }
    }
}