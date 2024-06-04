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
    public class CoachRepository : ICoachRepository
    {
        CommonProperties cProperties = new CommonProperties();

        public Coach GetCoachById(Guid coachId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Coach WHERE Id = @CoachId";
                return conn.QueryFirstOrDefault<Coach>(query, new { CoachId = coachId });
            }
        }

        public IEnumerable<Coach> GetAllCoaches()
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "SELECT * FROM Coach";
                return conn.Query<Coach>(query);
            }
        }

        public void AddCoach(Coach coach)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = @"INSERT INTO Coach (Id, Name, Specialization, ExperienceYears, ContactInfo) 
                             VALUES (@Id, @Name, @Specialization, @ExperienceYears, @ContactInfo)";
                conn.Execute(query, coach);
            }
        }

        public void UpdateCoach(Coach coach)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = @"UPDATE Coach
                             SET Name = @Name, Specialization = @Specialization, 
                                 ExperienceYears = @ExperienceYears, ContactInfo = @ContactInfo
                             WHERE Id = @Id";
                conn.Execute(query, coach);
            }
        }

        public void DeleteCoach(Guid coachId)
        {
            MySqlConnection conn = new MySqlConnection(cProperties.connectionString);
            using (conn)
            {
                conn.Open();
                string query = "DELETE FROM Coach WHERE Id = @CoachId";
                conn.Execute(query, new { CoachId = coachId });
            }
        }
    }
}
