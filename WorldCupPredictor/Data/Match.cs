using Prism.Mvvm;
using System;

namespace WorldCupPredictor.Data
{
    public class Match : BindableBase
    {
        private DateTime time;

        private uint? _homeScore;
        private uint? _awayScore;

        private string _homeScoreString;
        private string _awayScoreString;

        private Result _result;

        public Match(int id, DateTime time, Team teamHome, Team teamAway)
        {
            this.Id = id;
            this.time = time;
            this.TeamHome = teamHome;
            this.TeamAway = teamAway;

            this._result = Result.NotPlayed;
        }

        public int Id { get; }

        public DateTime Time => this.time.ToLocalTime();

        public Team TeamHome { get; }

        public Team TeamAway { get; }

        public string HomeScoreString
        {
            get => this._homeScoreString;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && uint.TryParse(value, out var score))
                {
                    this.SetProperty(ref this._homeScoreString, value);
                    this.HomeScore = score;
                }
                else
                {
                    this.SetProperty(ref this._homeScoreString, string.Empty);
                    this.HomeScore = null;
                }

                this.TeamHome.Group.UpdateTable();
            }
        }

        public uint? HomeScore
        {
            get => this._homeScore;
            set => this.SetProperty(ref this._homeScore, value);
        }

        public string AwayScoreString
        {
            get => this._awayScoreString;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && uint.TryParse(value, out var score))
                {
                    this.SetProperty(ref this._awayScoreString, value);
                    this.AwayScore = score;
                }
                else
                {
                    this.SetProperty(ref this._awayScoreString, string.Empty);
                    this.AwayScore = null;
                }

                this.TeamAway.Group.UpdateTable();
            }
        }

        public uint? AwayScore
        {
            get => this._awayScore;
            set => this.SetProperty(ref this._awayScore, value);
        }

        public Result Result
        {
            get => this._result;
            set => this.SetProperty(ref this._result, value);
        }


        public void UpdateResult()
        {
            this.Result = !HomeScore.HasValue || !AwayScore.HasValue ? Result.NotPlayed :
                          HomeScore == AwayScore ? Result.Draw :
                          HomeScore > AwayScore ? Result.HomeWin :
                          Result.AwayWin;
        }
    }

    public enum Result
    {
        NotPlayed,
        Draw,
        HomeWin,
        AwayWin
    }
}
