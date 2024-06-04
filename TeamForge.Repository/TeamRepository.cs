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
    public class TeamRepository : ITeamRepository
    {
        CommonProperties cProperties = new CommonProperties();
        public Team GetById(Guid id)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Team WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Team>(query, new { Id = id });
            }
        }

        public List<Team> GetAll()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Team";
                return conn.Query<Team>(query).ToList();
            }
        }

        public void Add(Team team)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "INSERT INTO Team (Id, Name, CoachName, PracticeSchedule) " +
                               "VALUES (@Id, @Name, @CoachName, @PracticeSchedule)";
                conn.Execute(query, team);
            }
        }

        public void Update(Team team)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "UPDATE Team SET Name = @Name, CoachName = @CoachName, " +
                               "PracticeSchedule = @PracticeSchedule WHERE Id = @Id";
                conn.Execute(query, team);
            }
        }

        public void Delete(Guid id)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "DELETE FROM Team WHERE Id = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
