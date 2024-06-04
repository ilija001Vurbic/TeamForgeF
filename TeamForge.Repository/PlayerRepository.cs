using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Common;
using TeamForge.Model;
using TeamForge.Repository.Common;

namespace TeamForge.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public Player GetById(Guid id)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Player WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Player>(query, new { Id = id });
            }
        }

        public List<Player> GetAll()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Player";
                return conn.Query<Player>(query).ToList();
            }
        }

        public void Add(Player player)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "INSERT INTO Player (Id, Name, Height, Weight, Age, Blocking, Attacking, Serving, Passing, Setting) " +
                               "VALUES (@Id, @Name, @Height, @Weight, @Age, @Blocking, @Attacking, @Serving, @Passing, @Setting)";
                conn.Execute(query, player);
            }
        }

        public void Update(Player player)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "UPDATE Player SET Name = @Name, Height = @Height, Weight = @Weight, " +
                               "Age = @Age, Blocking = @Blocking, Attacking = @Attacking, " +
                               "Serving = @Serving, Passing = @Passing, Setting = @Setting " +
                               "WHERE Id = @Id";
                conn.Execute(query, player);
            }
        }

        public void Delete(Guid id)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "DELETE FROM Player WHERE Id = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
        public List<Player> GetPlayers(string sortBy, bool isDescending, string filterBy, string filterValue, int pageNumber, int pageSize, out int totalRecords)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                var query = "SELECT * FROM Player WHERE 1 = 1";
                if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(filterValue))
                {
                    query += $" AND {filterBy} LIKE '%{filterValue}%'";
                }

                if (!string.IsNullOrEmpty(sortBy))
                {
                    query += $" ORDER BY {sortBy} {(isDescending ? "DESC" : "ASC")}";
                }

                var pagedQuery = $"{query} LIMIT @PageSize OFFSET @Offset";

                var players = conn.Query<Player>(pagedQuery, new { PageSize = pageSize, Offset = (pageNumber - 1) * pageSize }).ToList();
                totalRecords = conn.ExecuteScalar<int>($"SELECT COUNT(*) FROM Player WHERE 1 = 1 {(string.IsNullOrEmpty(filterBy) ? "" : $"AND {filterBy} LIKE '%{filterValue}%'")}");
                return players;
            }
        }
    }
}
