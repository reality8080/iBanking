using iBanking.Interfaces.Repo;
using iBanking.Models.Cuong;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iBanking.Repository.Cuong
{
    public class RepoEmployee : IRepoEmployee
    {
        private readonly string connectionString;
        private readonly ILogger<RepoEmployee> logger;

        public RepoEmployee(string connectionString, ILogger<RepoEmployee> logger)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> createEmployee(Employee e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Employee (name,password,salary,email,start_at,manager) VALUES (@name,@password,@salary,@email,@start_at,@manager)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@name", e.Username);
                    command.Parameters.AddWithValue("@password", e.Password);
                    command.Parameters.AddWithValue("@salary", e.Salary);
                    command.Parameters.AddWithValue("@email", e.Email);
                    command.Parameters.AddWithValue("@start_at", e.CreatedAt);
                    if (e.Manager != null)
                    {
                        command.Parameters.AddWithValue("@manager", e.Manager);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@manager", DBNull.Value);
                    }
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        logger.LogInformation($"User {e.Username} created successfully.");
                        MessageBox.Show($"User {e.Username} created successfully.");
                        return true;

                    }
                    else
                    {
                        logger.LogError($"Failed to create {e.Username}.");
                        MessageBox.Show($"Failed to create {e.Username}.");
                        return false;
                    }
                }
            }
        }

        public async Task<bool> delete(Employee e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Employee WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", e.Id);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        logger.LogInformation($"User: {e.Username} deleted successfully.");
                        MessageBox.Show($"User: {e.Username} deleted successfully.");
                        return true;
                    }
                    else
                    {
                        logger.LogError($"Failed to delete {e.Username}.");
                        MessageBox.Show($"Failed to delete {e.Username}.");
                        return false;
                    }
                }
            }
        }

        public async Task<IEnumerable<Employee>> readAllEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Employee";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Employee> E = new List<Employee>();
                        while (reader.Read())
                        {
                            decimal salary = reader.IsDBNull(3) ? 0.0m : reader.GetDecimal(3);
                            int? idManager= reader.IsDBNull(6)? (int?)null: reader.GetInt32(6);
                            Employee e = new Employee(
                                reader.GetInt32(0),
                                reader.GetString(2),
                                reader.GetString(1),
                                salary,
                                reader.GetString(4),
                                reader.GetDateTime(5),
                                idManager
                            );
                            E.Add(e);
                        }
                        if (E.Count == 0)
                        {
                            logger.LogWarning("The database Empty");
                            MessageBox.Show("The database Empty");
                            return Enumerable.Empty<Employee>();
                        }
                        else
                        {
                            logger.LogInformation($"{E.Count} users found.");
                            MessageBox.Show($"{E.Count} users found.");
                            return  E;
                        }
                    }
                }
            }
        }

        public async Task<Employee> readEmployeeByEmployeename(string name, string email, int? idManager)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Employee WHERE name = @name AND manager = @manager  AND email = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    if (!idManager.HasValue)
                    {
                        command.Parameters.AddWithValue("@manager", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@manager", idManager);
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal salary = reader.IsDBNull(3) ? 0.0m : reader.GetDecimal(3);
                            //int? idManager = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);
                            Employee e = new Employee(
                                reader.GetInt32(0),
                                reader.GetString(2),
                                reader.GetString(1),
                                salary,
                                reader.GetString(4),
                                reader.GetDateTime(5),
                                idManager
                            );
                            logger.LogInformation($"User with username {name} found.");
                            //MessageBox.Show($"User with username {username} found.");
                            return e;
                        }
                        else
                        {
                            logger.LogWarning($"User with username {name} not found.");
                            throw new KeyNotFoundException($"User with username {name} not found");
                        }
                    }
                }
            }
        }

        public async Task<Employee> readEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Employee WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal salary = reader.IsDBNull(3) ? 0.0m : reader.GetDecimal(3);
                            int? idManager = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);
                            Employee e = new Employee(
                                reader.GetInt32(0),
                                reader.GetString(2),
                                reader.GetString(1),
                                salary,
                                reader.GetString(4),
                                reader.GetDateTime(5),
                                idManager
                            );
                            logger.LogInformation($"User with ID {id} found.");
                            MessageBox.Show($"User with ID {id} found.");
                            return e;
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

        public async Task<bool> update(int id, Employee e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "UPDATE [User] SET name = @name, password = @password, salary = @salary, email = @email,start_at=@start_at,manager=@manager WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", e.Username);
                    command.Parameters.AddWithValue("@password", e.Password);
                    command.Parameters.AddWithValue("@salary", e.Salary);
                    command.Parameters.AddWithValue("@email", e.Email);
                    command.Parameters.AddWithValue("@start_at", e.CreatedAt);
                    command.Parameters.AddWithValue("@manager", e.Manager);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        logger.LogInformation($"User: {e.Username} updated successfully.");
                        MessageBox.Show("User updated successfully.");
                        return true;
                    }
                    else
                    {
                        logger.LogError($"Failed to update {e.Username}.");
                        return false;
                    }
                }
            }
        }
    }
}
