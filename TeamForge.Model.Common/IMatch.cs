using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TeamForge.Model.Common
{

    public interface IMatch
    {
        DateTime DateTime { get; set; }
        string Location { get; set; }
        List<ITeam> Teams { get; set; }
        List<IScore> Scores { get; set; }
    }
}
