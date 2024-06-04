using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model
{
    public class Team : ITeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICoach Coach { get; set; } // Reference to the coach of the team
        public List <IPlayer> Players { get; set; } // List of players in the team
        public string PracticeSchedule { get; set; } // Schedule for team practices
        public List <IMatch> Matches { get; set; } // List of matches played by the team
    }
}
