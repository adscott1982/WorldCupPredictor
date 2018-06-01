using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldCupPredictor.Data
{
    public class Group
    {
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

            this.Teams = teams.Distinct().ToList();
        }

        public string Name { get; }
        public List<Match> Matches { get; }
        public List<Team> Teams { get; }

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
            });

            this.b = new Group("B", new List<Match>
            {
                new Match(3, new DateTime(2018, 6, 15, 15, 0, 0, DateTimeKind.Utc), Teams.Morocco, Teams.Iran),
                new Match(4, new DateTime(2018, 6, 15, 18, 0, 0, DateTimeKind.Utc), Teams.Portugal, Teams.Spain)
            });

            this.c = new Group("C", new List<Match>
            {
                new Match(5, new DateTime(2018, 6, 16, 10, 0, 0, DateTimeKind.Utc), Teams.France, Teams.Australia),
                new Match(6, new DateTime(2018, 6, 16, 16, 0, 0, DateTimeKind.Utc), Teams.Peru, Teams.Denmark)
            });

            this.d = new Group("D", new List<Match>
            {
                new Match(7, new DateTime(2018, 6, 16, 13, 0, 0, DateTimeKind.Utc), Teams.Argentina, Teams.Iceland),
                new Match(8, new DateTime(2018, 6, 16, 19, 0, 0, DateTimeKind.Utc), Teams.Croatia, Teams.Nigeria)
            });

            this.e = new Group("E", new List<Match>
            {
                new Match(9, new DateTime(2018, 6, 17, 12, 0, 0, DateTimeKind.Utc), Teams.CostaRica, Teams.Serbia),
                new Match(10, new DateTime(2018, 6, 17, 18, 0, 0, DateTimeKind.Utc), Teams.Brazil, Teams.Switzerland)
            });

            this.f = new Group("F", new List<Match>
            {
                new Match(11, new DateTime(2018, 6, 17, 15, 0, 0, DateTimeKind.Utc), Teams.Germany, Teams.Mexico),
                new Match(12, new DateTime(2018, 6, 18, 12, 0, 0, DateTimeKind.Utc), Teams.Sweden, Teams.SouthKorea)
            });

            this.g = new Group("G", new List<Match>
            {
                new Match(13, new DateTime(2018, 6, 18, 15, 0, 0, DateTimeKind.Utc), Teams.Belgium, Teams.Panama),
                new Match(14, new DateTime(2018, 6, 18, 18, 0, 0, DateTimeKind.Utc), Teams.Tunisia, Teams.England)
            });

            this.h = new Group("H", new List<Match>
            {
                new Match(15, new DateTime(2018, 6, 19, 12, 0, 0, DateTimeKind.Utc), Teams.Colombia, Teams.Japan),
                new Match(16, new DateTime(2018, 6, 19, 15, 0, 0, DateTimeKind.Utc), Teams.Poland, Teams.Senegal)
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