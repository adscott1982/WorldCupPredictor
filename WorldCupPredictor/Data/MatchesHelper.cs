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
        }
    }
}
