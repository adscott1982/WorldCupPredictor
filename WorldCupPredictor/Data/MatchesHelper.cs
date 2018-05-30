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
            yield return new Match(1, new DateTime(2018, 6, 14, 15, 0, 0, DateTimeKind.Utc), Teams.Russia, Teams.SaudiArabia);

            yield return new Match(2, new DateTime(2018, 6, 15, 12, 0, 0, DateTimeKind.Utc), Teams.Egypt, Teams.Uruguay);
            yield return new Match(3, new DateTime(2018, 6, 15, 15, 0, 0, DateTimeKind.Utc), Teams.Morocco, Teams.Iran);
            yield return new Match(4, new DateTime(2018, 6, 15, 18, 0, 0, DateTimeKind.Utc), Teams.Portugal, Teams.Spain);

            yield return new Match(5, new DateTime(2018, 6, 16, 10, 0, 0, DateTimeKind.Utc), Teams.France, Teams.Australia);
            yield return new Match(6, new DateTime(2018, 6, 16, 13, 0, 0, DateTimeKind.Utc), Teams.Argentina, Teams.Iceland);
            yield return new Match(7, new DateTime(2018, 6, 16, 16, 0, 0, DateTimeKind.Utc), Teams.Peru, Teams.Denmark);
            yield return new Match(8, new DateTime(2018, 6, 16, 19, 0, 0, DateTimeKind.Utc), Teams.Croatia, Teams.Nigeria);

            yield return new Match(9, new DateTime(2018, 6, 17, 12, 0, 0, DateTimeKind.Utc), Teams.CostaRica, Teams.Serbia);
            yield return new Match(10, new DateTime(2018, 6, 17, 15, 0, 0, DateTimeKind.Utc), Teams.Germany, Teams.Mexico);
            yield return new Match(11, new DateTime(2018, 6, 17, 18, 0, 0, DateTimeKind.Utc), Teams.Brazil, Teams.Switzerland);
        }
    }
}
