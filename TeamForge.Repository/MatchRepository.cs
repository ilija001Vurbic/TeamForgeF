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
    public class MatchRepository : IMatchRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public Match GetById(Guid id)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Match WHERE Id = @Id";
                var match = conn.Query<Match>(query, new { Id = id }).FirstOrDefault();
                return match;
            }
        }

        public List<Match> GetAll()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Match";
                var matches = conn.Query<Match>(query).ToList();
                return matches;
            }
        }

        public void Add(Match match)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "INSERT INTO Match (Id, DateTime, Location) VALUES (@Id, @DateTime, @Location)";
                conn.Execute(query, match);
            }
        }

        public void Update(Match match)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            { 
                conn.Open();
                string query = "UPDATE Match SET DateTime = @DateTime, Location = @Location WHERE Id = @Id";
                conn.Execute(query, match);
            }
        }

        public void Delete(Guid id)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "DELETE FROM Match WHERE Id = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
