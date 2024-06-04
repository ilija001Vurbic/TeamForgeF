using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface IMatchRepository
    {
        Match GetById(Guid id);
        List<Match> GetAll();
        void Add(Match match);
        void Update(Match match);
        void Delete(Guid id);
    }
}
