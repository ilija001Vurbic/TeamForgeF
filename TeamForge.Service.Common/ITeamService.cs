using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface ITeamService
    {
        Team GetTeamById(Guid id);
        List<Team> GetAllTeams();
        void AddTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(Guid id);
    }
}
