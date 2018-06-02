using System;

namespace WorldCupPredictor.Data
{
    public class Match
    {
        private DateTime time;

        public Match(int id, DateTime time, Team teamHome, Team teamAway)
        {
            this.Id = id;
            this.time = time;
            this.TeamHome = teamHome;
            this.TeamAway = teamAway;
        }

        public int Id { get; }

        public DateTime Time => this.time.ToLocalTime();

        public Team TeamHome { get; }

        public Team TeamAway { get; }

        public int HomeScore { get; }

        public int AwayScore { get; }

        public Result Result => 
            HomeScore == AwayScore ? Result.Draw :
            HomeScore > AwayScore ? Result.HomeWin :
            Result.AwayWin;
    }

    public enum Result
    {
        Draw,
        HomeWin,
        AwayWin
    }
}
