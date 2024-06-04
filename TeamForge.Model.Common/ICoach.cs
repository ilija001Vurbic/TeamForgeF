using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface ICoach
    {
        string Name { get; set; }
        string Specialization { get; set; }
        int ExperienceYears { get; set; }
        string ContactInfo { get; set; }
    }
}
