using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldCupPredictor.Data
{
    internal static class MatchesHelper
    {
        public static IEnumerable<MatchDay> GetAllMatchDays()
        {
            foreach(var matchday in GetAllMatches()
                .GroupBy(match => match.Time.StripTimeOfDay())
                .OrderBy(item => item.Key))
            {
                yield return new MatchDay(matchday.Key, matchday);
            }
        }

        private static DateTime StripTimeOfDay(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day);
        }


        private static IEnumerable<Match> GetAllMatches()
        {
            yield return new Match(new DateTime(2018, 6, 14, 15, 0, 0, DateTimeKind.Utc), Team.Russia, Team.SaudiArabia);

            yield return new Match(new DateTime(2018, 6, 15, 12, 0, 0, DateTimeKind.Utc), Team.Egypt, Team.Uruguay);
            yield return new Match(new DateTime(2018, 6, 15, 15, 0, 0, DateTimeKind.Utc), Team.Morocco, Team.Iran);
            yield return new Match(new DateTime(2018, 6, 15, 18, 0, 0, DateTimeKind.Utc), Team.Portugal, Team.Spain);

            yield return new Match(new DateTime(2018, 6, 16, 10, 0, 0, DateTimeKind.Utc), Team.France, Team.Australia);
            yield return new Match(new DateTime(2018, 6, 16, 13, 0, 0, DateTimeKind.Utc), Team.Argentina, Team.Iceland);
            yield return new Match(new DateTime(2018, 6, 16, 16, 0, 0, DateTimeKind.Utc), Team.Peru, Team.Denmark);
            yield return new Match(new DateTime(2018, 6, 16, 19, 0, 0, DateTimeKind.Utc), Team.Croatia, Team.Nigeria);
        }
    }
}
