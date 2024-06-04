using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface ITeam
    {
        string Name { get; set; }
        ICoach Coach { get; set; }
        List<IPlayer> Players { get; set; }
        string PracticeSchedule { get; set; }
        List<IMatch> Matches { get; set; }
    }

}
