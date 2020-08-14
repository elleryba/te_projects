using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Carts
{
    public class CartSqlDao : ICartDao
    {
        private readonly string connectionString;

        public CartSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Cart> GetAllCarts()
        {
            IList<Cart> carts = new List<Cart>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT id, username, cookie_value, created FROM carts";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    carts.Add(new Cart
                    {
                        CookieValue = reader["cookie_value"] as string,
                        Created = (DateTime)reader["created"],
                        Id = (int)reader["id"],
                        Username = reader["username"] as string
                    });
                }
            }

            return carts;
        }

        public void Save(Cart newCart)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO carts(username, cookie_value, created) VALUES (@username, @cookie_value, @created); SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
                command.Parameters.AddWithValue("@username", newCart.Username);
                command.Parameters.AddWithValue("@cookie_value", newCart.CookieValue);
                command.Parameters.AddWithValue("@created", newCart.Created);

                connection.Open();

                newCart.Id = (long)command.ExecuteScalar();
            }
        }
    }
}