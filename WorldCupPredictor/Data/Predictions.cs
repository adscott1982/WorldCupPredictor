using System.Collections.Generic;
using System.Linq;

namespace WorldCupPredictor.Data
{
    public class Predictions
    {
        public Predictions()
        {
        }

        public Predictions(IEnumerable<Match> matches, IEnumerable<Group> groups)
        {
            this.MatchPredictions = matches.Select(match => new MatchPrediction
            {
                Id = match.Id,
                HomeTeam = match.TeamHome.Name,
                AwayTeam = match.TeamAway.Name,
                HomeScore = match.HomeScore.Value,
                AwayScore = match.AwayScore.Value
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

        public IEnumerable<MatchPrediction> MatchPredictions { get; set; }

        public IEnumerable<TablePrediction> TablePredictions { get; set; }
    }
}
