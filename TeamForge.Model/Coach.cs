using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model
{
    public class Coach
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; } // Coaching specialization (e.g., offense, defense, setter coach)
        public int ExperienceYears { get; set; } // Years of coaching experience
        public string ContactInfo { get; set; } // Contact information for the coach
    }
}
