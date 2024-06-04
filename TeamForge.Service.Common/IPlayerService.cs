using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface IPlayerService
    {
        Player GetPlayerById(Guid id);
        List<Player> GetAllPlayers();
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Guid id);
        public List<Player> GetPlayers(string sortBy, bool isDescending, string filterBy, string filterValue, int pageNumber, int pageSize, out int totalRecords);
    }
}
