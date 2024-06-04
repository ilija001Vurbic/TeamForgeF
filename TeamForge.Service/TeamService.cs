using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;
using TeamForge.Repository.Common;
using TeamForge.Service.Common;

namespace TeamForge.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Team GetTeamById(Guid id)
        {
            return teamRepository.GetById(id);
        }

        public List<Team> GetAllTeams()
        {
            return teamRepository.GetAll();
        }

        public void AddTeam(Team team)
        {
            // Additional logic can be implemented here (e.g., validation)
            teamRepository.Add(team);
        }

        public void UpdateTeam(Team team)
        {
            // Additional logic can be implemented here (e.g., validation)
            teamRepository.Update(team);
        }

        public void DeleteTeam(Guid id)
        {
            // Additional logic can be implemented here (e.g., check if team exists)
            teamRepository.Delete(id);
        }
    }
}
