// Services/UserService.cs
using System;
using System.Threading.Tasks;
using SbAdmin.Models;  // Assuming FactoryUserModel is located here
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BC = BCrypt.Net.BCrypt;

namespace SbAdmin.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        // Constructor to inject the database connection string from configuration
        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // AddUser method
        public async Task<bool> AddUser(FactoryUserModel.Register user)
        {
            Console.WriteLine("start");
             return false;
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            // Hash the password before storing
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.factory_password);

            try
            {
                // Open a connection to the database
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // SQL query to insert user into the database
                    string query = @"
                        INSERT INTO Users (FactoryEmail, FactoryPassword)
                        VALUES (@FactoryEmail, @FactoryPassword);";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FactoryEmail", user.factory_email);
                        command.Parameters.AddWithValue("@FactoryPassword", hashedPassword);

                        // Execute the query and return true if one row is affected
                        var result = await command.ExecuteNonQueryAsync();
                        return result > 0; // Return true if user was added
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
