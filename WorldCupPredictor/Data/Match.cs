using System;

namespace WorldCupPredictor.Data
{
    public class Match
    {
        private DateTime time;

        public Match(DateTime time, Team teamHome, Team teamAway)
        {
            this.time = time;
            this.TeamHome = teamHome;
            this.TeamAway = teamAway;
        }

        public DateTime Time => this.time.ToLocalTime();

        public Team TeamHome { get; }

        public Team TeamAway { get; }

    }
}
