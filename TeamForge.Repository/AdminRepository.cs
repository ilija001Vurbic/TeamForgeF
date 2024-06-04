using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Common;
using TeamForge.Model;
using TeamForge.Repository.Common;

namespace TeamForge.Repository
{
    public class AdminRepository : IAdminRepository
    {
        CommonProperties cProperties = new CommonProperties();
        public Admin GetAdminById(Guid adminId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                string query = "SELECT * FROM Admin WHERE Id = @AdminId";
                return conn.QueryFirstOrDefault<Admin>(query, new { AdminId = adminId });
            }
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                string query = "SELECT * FROM Admin";
                return conn.Query<Admin>(query).ToList();
            }
        }

        public void AddAdmin(Admin admin)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                string query = @"INSERT INTO Admin (Id, Username, Email, PasswordHash)
                             VALUES (@Id, @Username, @Email, @PasswordHash)";
                conn.Execute(query, admin);
            }
        }

        public void UpdateAdmin(Admin admin)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                string query = @"UPDATE Admin 
                             SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash
                             WHERE Id = @Id";
                conn.Execute(query, admin);
            }
        }

        public void DeleteAdmin(Guid adminId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                string query = "DELETE FROM Admin WHERE Id = @AdminId";
                conn.Execute(query, new { AdminId = adminId });
            }
        }
    }
}
