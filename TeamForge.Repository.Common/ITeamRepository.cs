using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface ITeamRepository
    {
        Team GetById(Guid id);
        List<Team> GetAll();
        void Add(Team team);
        void Update(Team team);
        void Delete(Guid id);
    }
}
