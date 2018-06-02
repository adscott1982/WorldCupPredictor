using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldCupPredictor.Data
{
    public class Group
    {
        private List<Team> teams;

        private Group()
        {
        }

        public Group(string name, List<Match> matches)
        {
            this.Name = name;
            this.Matches = matches;

            var teams = new List<Team>();

            // Get all the unique teams out of the matches, and assign this group to the teams
            matches.ForEach(match =>
            {
                match.TeamHome.Group = this;
                match.TeamAway.Group = this;

                teams.Add(match.TeamHome);
                teams.Add(match.TeamAway);
            });

            this.teams = teams.Distinct().OrderBy(team => team.Name).ToList();
        }

        public string Name { get; }
        public List<Match> Matches { get; }
        public List<Team> Table
        {
            get
            {
                var initialOrder = this.teams.OrderByDescending(team => team.Points)
                    .ThenByDescending(team => team.GoalDifference)
                    .ThenByDescending(team => team.GoalsScored).ToList();

                var updatedOrder = initialOrder.ToList();

                // If teams have the same points, GD, GS, alter position by VS result
                for (var i = 0; i < initialOrder.Count - 1; i++)
                {
                    var team1 = initialOrder[i];
                    var team2 = initialOrder[i + 1];

                    if (team1.Points == team2.Points &&
                        team1.GoalDifference == team2.GoalDifference &&
                        team1.GoalsScored == team2.GoalsScored)
                    {
                        var match = this.Matches.Find(m =>
                        m.TeamHome == team1 || m.TeamAway == team1 &&
                        m.TeamHome == team2 || m.TeamAway == team2);

                        var team2Won = (match.TeamHome == team2 && match.Result == Result.HomeWin) ||
                            (match.TeamAway == team2 && match.Result == Result.AwayWin);

                        if (team2Won)
                        {
                            var teamToDropAPlace = updatedOrder[i];
                            updatedOrder[i] = updatedOrder[i+1];
                            updatedOrder[i+1] = teamToDropAPlace;
                        }
                    }
                }

                return updatedOrder;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }

    public class Groups
    {
        private static Groups instance = null;
        private Group a;
        private Group b;
        private Group c;
        private Group d;
        private Group e;
        private Group f;
        private Group g;
        private Group h;

        private Groups()
        {
            this.a = new Group("A", new List<Match>
            {
                new Match(1, new DateTime(2018, 6, 14, 15, 0, 0, DateTimeKind.Utc), Teams.Russia, Teams.SaudiArabia),
                new Match(2, new DateTime(2018, 6, 15, 12, 0, 0, DateTimeKind.Utc), Teams.Egypt, Teams.Uruguay),

                new Match(3, new DateTime(2018, 6, 19, 18, 0, 0, DateTimeKind.Utc), Teams.Russia, Teams.Egypt),
                new Match(4, new DateTime(2018, 6, 20, 15, 0, 0, DateTimeKind.Utc), Teams.Uruguay, Teams.SaudiArabia),

                new Match(5, new DateTime(2018, 6, 25, 14, 0, 0, DateTimeKind.Utc), Teams.SaudiArabia, Teams.Egypt),
                new Match(6, new DateTime(2018, 6, 25, 14, 0, 0, DateTimeKind.Utc), Teams.Uruguay, Teams.Russia)
            });

            this.b = new Group("B", new List<Match>
            {
                new Match(7, new DateTime(2018, 6, 15, 15, 0, 0, DateTimeKind.Utc), Teams.Morocco, Teams.Iran),
                new Match(8, new DateTime(2018, 6, 15, 18, 0, 0, DateTimeKind.Utc), Teams.Portugal, Teams.Spain),

                new Match(9, new DateTime(2018, 6, 20, 12, 0, 0, DateTimeKind.Utc), Teams.Portugal, Teams.Morocco),
                new Match(10, new DateTime(2018, 6, 20, 18, 0, 0, DateTimeKind.Utc), Teams.Iran, Teams.Spain),

                new Match(11, new DateTime(2018, 6, 25, 18, 0, 0, DateTimeKind.Utc), Teams.Iran, Teams.Portugal),
                new Match(12, new DateTime(2018, 6, 25, 18, 0, 0, DateTimeKind.Utc), Teams.Spain, Teams.Morocco)
            });

            this.c = new Group("C", new List<Match>
            {
                new Match(13, new DateTime(2018, 6, 16, 10, 0, 0, DateTimeKind.Utc), Teams.France, Teams.Australia),
                new Match(14, new DateTime(2018, 6, 16, 16, 0, 0, DateTimeKind.Utc), Teams.Peru, Teams.Denmark),

                new Match(15, new DateTime(2018, 6, 21, 12, 0, 0, DateTimeKind.Utc), Teams.Denmark, Teams.Australia),
                new Match(16, new DateTime(2018, 6, 21, 15, 0, 0, DateTimeKind.Utc), Teams.France, Teams.Peru),

                new Match(17, new DateTime(2018, 6, 26, 14, 0, 0, DateTimeKind.Utc), Teams.Australia, Teams.Peru),
                new Match(18, new DateTime(2018, 6, 26, 14, 0, 0, DateTimeKind.Utc), Teams.Denmark, Teams.France)
            });

            this.d = new Group("D", new List<Match>
            {
                new Match(19, new DateTime(2018, 6, 16, 13, 0, 0, DateTimeKind.Utc), Teams.Argentina, Teams.Iceland),
                new Match(20, new DateTime(2018, 6, 16, 19, 0, 0, DateTimeKind.Utc), Teams.Croatia, Teams.Nigeria),

                new Match(21, new DateTime(2018, 6, 21, 18, 0, 0, DateTimeKind.Utc), Teams.Argentina, Teams.Croatia),
                new Match(22, new DateTime(2018, 6, 22, 15, 0, 0, DateTimeKind.Utc), Teams.Nigeria, Teams.Iceland),

                new Match(23, new DateTime(2018, 6, 26, 18, 0, 0, DateTimeKind.Utc), Teams.Iceland, Teams.Croatia),
                new Match(24, new DateTime(2018, 6, 26, 18, 0, 0, DateTimeKind.Utc), Teams.Nigeria, Teams.Argentina)
            });

            this.e = new Group("E", new List<Match>
            {
                new Match(25, new DateTime(2018, 6, 17, 12, 0, 0, DateTimeKind.Utc), Teams.CostaRica, Teams.Serbia),
                new Match(26, new DateTime(2018, 6, 17, 18, 0, 0, DateTimeKind.Utc), Teams.Brazil, Teams.Switzerland),

                new Match(27, new DateTime(2018, 6, 22, 12, 0, 0, DateTimeKind.Utc), Teams.Brazil, Teams.CostaRica),
                new Match(28, new DateTime(2018, 6, 22, 18, 0, 0, DateTimeKind.Utc), Teams.Serbia, Teams.Switzerland),

                new Match(29, new DateTime(2018, 6, 27, 18, 0, 0, DateTimeKind.Utc), Teams.Serbia, Teams.Brazil),
                new Match(30, new DateTime(2018, 6, 27, 18, 0, 0, DateTimeKind.Utc), Teams.Switzerland, Teams.CostaRica)
            });

            this.f = new Group("F", new List<Match>
            {
                new Match(31, new DateTime(2018, 6, 17, 15, 0, 0, DateTimeKind.Utc), Teams.Germany, Teams.Mexico),
                new Match(32, new DateTime(2018, 6, 18, 12, 0, 0, DateTimeKind.Utc), Teams.Sweden, Teams.SouthKorea),

                new Match(33, new DateTime(2018, 6, 23, 15, 0, 0, DateTimeKind.Utc), Teams.SouthKorea, Teams.Mexico),
                new Match(34, new DateTime(2018, 6, 23, 18, 0, 0, DateTimeKind.Utc), Teams.Germany, Teams.Sweden),

                new Match(35, new DateTime(2018, 6, 27, 14, 0, 0, DateTimeKind.Utc), Teams.SouthKorea, Teams.Germany),
                new Match(36, new DateTime(2018, 6, 27, 14, 0, 0, DateTimeKind.Utc), Teams.Mexico, Teams.Sweden)
            });

            this.g = new Group("G", new List<Match>
            {
                new Match(37, new DateTime(2018, 6, 18, 15, 0, 0, DateTimeKind.Utc), Teams.Belgium, Teams.Panama),
                new Match(38, new DateTime(2018, 6, 18, 18, 0, 0, DateTimeKind.Utc), Teams.Tunisia, Teams.England),

                new Match(39, new DateTime(2018, 6, 23, 12, 0, 0, DateTimeKind.Utc), Teams.Belgium, Teams.Tunisia),
                new Match(40, new DateTime(2018, 6, 24, 12, 0, 0, DateTimeKind.Utc), Teams.England, Teams.Panama),

                new Match(41, new DateTime(2018, 6, 28, 18, 0, 0, DateTimeKind.Utc), Teams.England, Teams.Belgium),
                new Match(42, new DateTime(2018, 6, 28, 18, 0, 0, DateTimeKind.Utc), Teams.Panama, Teams.Tunisia)
            });

            this.h = new Group("H", new List<Match>
            {
                new Match(43, new DateTime(2018, 6, 19, 12, 0, 0, DateTimeKind.Utc), Teams.Colombia, Teams.Japan),
                new Match(44, new DateTime(2018, 6, 19, 15, 0, 0, DateTimeKind.Utc), Teams.Poland, Teams.Senegal),

                new Match(45, new DateTime(2018, 6, 24, 15, 0, 0, DateTimeKind.Utc), Teams.Japan, Teams.Senegal),
                new Match(46, new DateTime(2018, 6, 24, 18, 0, 0, DateTimeKind.Utc), Teams.Poland, Teams.Colombia),

                new Match(47, new DateTime(2018, 6, 28, 14, 0, 0, DateTimeKind.Utc), Teams.Japan, Teams.Poland),
                new Match(48, new DateTime(2018, 6, 28, 14, 0, 0, DateTimeKind.Utc), Teams.Senegal, Teams.Colombia)
            });
        }

        internal static Groups Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Groups();
                }

                return instance;
            }
        }

        internal static IEnumerable<Group> All
        {
            get
            {
                yield return A;
                yield return B;
                yield return C;
                yield return D;
                yield return E;
                yield return F;
                yield return G;
                yield return H;
            }
        }

        internal static Group A => Instance.a;
        internal static Group B => Instance.b;
        internal static Group C => Instance.c;
        internal static Group D => Instance.d;
        internal static Group E => Instance.e;
        internal static Group F => Instance.f;
        internal static Group G => Instance.g;
        internal static Group H => Instance.h;
    }
}