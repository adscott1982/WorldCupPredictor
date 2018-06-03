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

        internal static IEnumerable<Group> GetAllGroups()
        {
            return Groups.All;
        }

        private static IEnumerable<Match> GetAllMatches()
        {
            return Groups.All.SelectMany(group => group.Matches).OrderBy(match => match.Time);
        }
    }
}
