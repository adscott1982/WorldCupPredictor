using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupPredictor.Data
{
    public class MatchPrediction
    {
        public int Id { get; set; }
        public uint HomeScore { get; set; }
        public uint AwayScore { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public Result Result { get; set; }
    }
}
