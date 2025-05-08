using iBanking.Interfaces.Repo;
using iBanking.NewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Repository.Cuong
{
    public class RepoUser : IRepoUser
    {
        private readonly string connectionString;
        private readonly ILogger<RepoUser> logger;

        public RepoUser(ILogger<RepoUser> logger, string connectionString)
        {
            this.connectionString = connectionString?? throw new ArgumentNullException(connectionString);
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> createUser(User u)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO [User] ( name, password, email, start_at) VALUES ( @name, @password, @email, @createdAt)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@name",u.Name);
                    command.Parameters.AddWithValue("@password", u.Password);
                    command.Parameters.AddWithValue("@email", u.Email);
                    command.Parameters.AddWithValue("@createdAt", u.CreatedAt);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        logger.LogInformation($"User {u.Name} created successfully.");
                        MessageBox.Show($"User {u.Name} created successfully.");
                        return true;

                    }
                    else
                    {
                        logger.LogError($"Failed to create {u.Name}.");
                        MessageBox.Show($"Failed to create {u.Name}.");
                        return false;
                    }
                }
            }
        }

        public async Task<bool> delete(User u)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM [User] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", u.Id);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        logger.LogInformation($"User: {u.Name} deleted successfully.");
                        MessageBox.Show($"User: {u.Name} deleted successfully.");
                        return true;
                    }
                    else
                    {
                        logger.LogError($"Failed to delete {u.Name}.");
                        MessageBox.Show($"Failed to delete {u.Name}.");
                        return false;
                    }
                }
            }
        }

        public async Task<IEnumerable<User>> readAllUser()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM [User]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            decimal balance = reader.IsDBNull(3) ? 0.0m : reader.GetDecimal(3);
                            User user = new User(
                                reader.GetInt32(0),
                                reader.GetString(2),
                                reader.GetString(1),
                                balance,
                                reader.GetString(4),
                                reader.GetDateTime(5)
                            );
                            users.Add(user);
                        }
                        if (users.Count == 0)
                        {
                            logger.LogWarning("The database Empty");
                            MessageBox.Show("The database Empty");
                            return Enumerable.Empty<User>();
                        }
                        else
                        {
                            logger.LogInformation($"{users.Count} users found.");
                            MessageBox.Show($"{users.Count} users found.");
                            return users;
                        }
                    }
                }
            }
        }

        public async Task<User> readUserById(int id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                 await connection.OpenAsync();
                string query = "SELECT * FROM [User] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal balance = reader.IsDBNull(3) ? 0.0m : reader.GetDecimal(3);
                            User user = new User(
                                reader.GetInt32(0),
                                reader.GetString(2),
                                reader.GetString(1),
                                balance,
                                reader.GetString(4),
                                reader.GetDateTime(5)
                            );
                            logger.LogInformation($"User with ID {id} found.");
                            MessageBox.Show($"User with ID {id} found.");
                            return user;
                        }
                        else
                        {
                            logger.LogWarning($"User with ID {id} not found.");
                            throw new KeyNotFoundException($"User with ID {id} not found");
                        }
                    }
                }
            }
        }

        public async Task<User> readUserByUsername(string username)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM [User] WHERE name = @name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal balance = reader.IsDBNull(3) ? 0.0m : reader.GetDecimal(3);
                            User user = new User(
                                reader.GetInt32(0),
                                reader.GetString(2),
                                reader.GetString(1),
                                balance,
                                reader.GetString(4),
                                reader.GetDateTime(5)
                            );
                            logger.LogInformation($"User with username {username} found.");
                            //MessageBox.Show($"User with username {username} found.");
                            return user;
                        }
                        else
                        {
                            logger.LogWarning($"User with username {username} not found.");
                            throw new KeyNotFoundException($"User with username {username} not found");
                        }
                    }
                }
            }
        }

        public async Task<bool> update(int id, User u)
        {
            using(SqlConnection  conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "UPDATE [User] SET Username = @Username, Password = @Password, Balance = @Balance, Email = @Email WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@name",u.Name);
                    command.Parameters.AddWithValue("@Password", u.Password);
                    command.Parameters.AddWithValue("@Balance", u.Balance);
                    command.Parameters.AddWithValue("@Email", u.Email);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        logger.LogInformation($"User: {u.Name} updated successfully.");
                        MessageBox.Show("User updated successfully.");
                        return true;
                    }
                    else
                    {
                        logger.LogError($"Failed to update {u.Name}.");
                        return false;
                    }
                }
            }
        }
    }
}
