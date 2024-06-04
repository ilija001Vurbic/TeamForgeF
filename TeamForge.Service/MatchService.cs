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
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }

        public Match GetMatchById(Guid id)
        {
            return matchRepository.GetById(id);
        }

        public List<Match> GetAllMatches()
        {
            return matchRepository.GetAll();
        }

        public void AddMatch(Match match)
        {
            matchRepository.Add(match);
        }

        public void UpdateMatch(Match match)
        {
            matchRepository.Update(match);
        }

        public void DeleteMatch(Guid id)
        {
            matchRepository.Delete(id);
        }
    }
}
