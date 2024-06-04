using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model
{
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; } // Height of the player in inches
        public int Weight { get; set; } // Weight of the player in pounds
        public int Age { get; set; } // Age of the player
        public int Blocking { get; set; } // Blocking ability rating (out of 10)
        public int Attacking { get; set; } // Attacking ability rating (out of 10)
        public int Serving { get; set; } // Serving ability rating (out of 10)
        public int Passing { get; set; } // Passing ability rating (out of 10)
        public int Setting { get; set; } // Setting ability rating (out of 10)
        public int OverallRating
        {
            get { return (Blocking + Attacking + Serving + Passing + Setting) / 5; }
        }
    }
}
