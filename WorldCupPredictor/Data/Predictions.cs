using System.Collections.Generic;
using System.Linq;

namespace WorldCupPredictor.Data
{
    public class Predictions
    {
        public Predictions()
        {
        }

        public Predictions(string name, IEnumerable<Match> matches, IEnumerable<Group> groups)
        {
            this.Name = name;

            this.MatchPredictions = matches.Select(match => new MatchPrediction
            {
                Id = match.Id,
                HomeTeam = match.TeamHome.Name,
                AwayTeam = match.TeamAway.Name,
                HomeScore = match.HomeScore.Value,
                AwayScore = match.AwayScore.Value,
                Result = match.Result
            });

            this.TablePredictions = groups.Select(group => new TablePrediction
            {
                GroupName = group.Name,
                First = group.Table[0].Name,
                Second = group.Table[1].Name,
                Third = group.Table[2].Name,
                Fourth = group.Table[3].Name
            });
        }

        public string Name { get; set; }

        public IEnumerable<MatchPrediction> MatchPredictions { get; set; }

        public IEnumerable<TablePrediction> TablePredictions { get; set; }
    }
}
