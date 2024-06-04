using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;
using static System.Formats.Asn1.AsnWriter;

namespace TeamForge.Model
{
    public class Match : IMatch
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; } // Date and time of the match
        public string Location { get; set; } // Location of the match (e.g., venue name)
        public List <ITeam> Teams { get; set; } // List of teams participating in the match
        public List <IScore> Scores { get; set; } // Scores for each set played in the match
    }
}
