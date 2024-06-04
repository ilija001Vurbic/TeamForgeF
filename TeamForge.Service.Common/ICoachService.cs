using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface ICoachService
    {
        Coach GetCoachById(Guid coachId);
        IEnumerable<Coach> GetAllCoaches();
        void AddCoach(Coach coach);
        void UpdateCoach(Coach coach);
        void DeleteCoach(Guid coachId);
    }
}
