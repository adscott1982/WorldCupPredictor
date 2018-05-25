using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupPredictor.Data
{
    public class MatchDay
    {
        public MatchDay(DateTime day, IEnumerable<Match> matches)
        {
            this.Day = day;
            this.Matches = matches;
        }

        public DateTime Day { get; }

        public IEnumerable<Match> Matches { get; }
    }
}
