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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public Player GetPlayerById(Guid id)
        {
            return playerRepository.GetById(id);
        }

        public List<Player> GetAllPlayers()
        {
            return playerRepository.GetAll();
        }

        public void AddPlayer(Player player)
        {
            // Additional logic can be implemented here (e.g., validation)
            playerRepository.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            // Additional logic can be implemented here (e.g., validation)
            playerRepository.Update(player);
        }

        public void DeletePlayer(Guid id)
        {
            // Additional logic can be implemented here (e.g., check if player exists)
            playerRepository.Delete(id);
        }
        public List<Player> GetPlayers(string sortBy, bool isDescending, string filterBy, string filterValue, int pageNumber, int pageSize, out int totalRecords)
        {
            return playerRepository.GetPlayers(sortBy, isDescending, filterBy, filterValue, pageNumber, pageSize, out totalRecords);
        }
    }
}
