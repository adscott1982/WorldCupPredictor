using System.Collections.Generic;

namespace WorldCupPredictor.Data
{
    public class Predictions
    {
        public Predictions(IEnumerable<Match> matchPredictions, IEnumerable<Team> tablePredictions)
        {
                this.MatchPredictions = matchPredictions;
                this.TablePredictions = tablePredictions;
        }

        public IEnumerable<Match> MatchPredictions { get; }

        public object TablePredictions { get; }
    }
}
