using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface IPlayerRepository
    {
        Player GetById(Guid id);
        List<Player> GetAll();
        void Add(Player player);
        void Update(Player player);
        void Delete(Guid id);
        List<Player> GetPlayers(string sortBy, bool isDescending, string filterBy, string filterValue, int pageNumber, int pageSize, out int totalRecords);
    }
}
