using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Communities
{
    public class CommunitySqlDao : ICommunityDao
    {
        private readonly string connectionString;

        public CommunitySqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Community> GetAllCommunities()
        {
            IList<Community> communities = new List<Community>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT id, name, latitude, longitude, created, live 
                    FROM communities";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    communities.Add(new Community
                    {
                        Created = (DateTime)reader["created"],
                        Id = (int)reader["id"],
                        IsLive = (bool)reader["live"],
                        Latitude = (decimal)(reader["latitude"]),
                        Longitude = (decimal)reader["longitude"],
                        Name = reader["name"] as string
                    });
                }
            }

            return communities;
        }

        public void Save(Community newCommunity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO communities (name, latitude, longitude, created, live) 
                    VALUES (@name, @latitude, @longitude, @created, @live); 
                    SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
                command.Parameters.AddWithValue("@created", newCommunity.Created);
                command.Parameters.AddWithValue("@live", newCommunity.IsLive);    
                command.Parameters.AddWithValue("@latitude", newCommunity.Latitude);
                command.Parameters.AddWithValue("@longitude", newCommunity.Longitude);
                command.Parameters.AddWithValue("@name", newCommunity.Name);
                
                connection.Open();

                newCommunity.Id = (long)command.ExecuteScalar();
            }
        }
    }
}