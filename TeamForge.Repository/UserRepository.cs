using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamForge.Common;
using TeamForge.Model;
using TeamForge.Repository.Common;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace TeamForge.Repository
{
    public class UserRepository : IUserRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public User GetUserById(Guid userId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM User WHERE Id = @UserId";
                return conn.QueryFirstOrDefault<User>(query, new { UserId = userId });
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM User";
                return conn.Query<User>(query);
            }
        }

        public void AddUser(User user)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash); // Hash the password
                string query = @"INSERT INTO User (Id, Username, Email, PasswordHash)
                             VALUES (@Id, @Username, @Email, @PasswordHash)";
                conn.Execute(query, user);
            }
        }

        public void UpdateUser(User user)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash); // Hash the password
                string query = @"UPDATE User
                             SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash
                             WHERE Id = @Id";
                conn.Execute(query, user);
            }
        }

        public void DeleteUser(Guid userId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "DELETE FROM User WHERE Id = @UserId";
                conn.Execute(query, new { UserId = userId });
            }
        }

        public User GetUserByUsername(string username)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM User WHERE Username = @Username";
                return conn.QueryFirstOrDefault<User>(query, new { Username = username });
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}