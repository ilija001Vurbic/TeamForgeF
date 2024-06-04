using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface IMatchService
    {
        Match GetMatchById(Guid id);
        List<Match> GetAllMatches();
        void AddMatch(Match match);
        void UpdateMatch(Match match);
        void DeleteMatch(Guid id);
    }
}
