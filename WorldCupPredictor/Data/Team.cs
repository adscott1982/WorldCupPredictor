namespace WorldCupPredictor.Data
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
        }

        public string ImagePath => $@"\Flags\{Name.Replace(" ", string.Empty)}.png";

        public string Name { get; }

        internal static Team Russia => new Team("Russia");
        internal static Team SaudiArabia => new Team("Saudi Arabia");
        internal static Team Egypt => new Team("Egypt");
        internal static Team Uruguay => new Team("Uruguay");
        internal static Team Portugal => new Team("Portugal");
        internal static Team Spain => new Team("Spain");
        internal static Team Morocco => new Team("Morocco");
        internal static Team France => new Team("France");
        internal static Team Australia => new Team("Australia");
        internal static Team Peru => new Team("Peru");
        internal static Team Denmark => new Team("Denmark");
        internal static Team Argentina => new Team("Argentina");
        internal static Team Iceland => new Team("Iceland");
        internal static Team Croatia => new Team("Croatia");
        internal static Team Nigeria => new Team("Nigeria");
        internal static Team Brazil => new Team("Brazil");
        internal static Team Switzerland => new Team("Switzerland");
        internal static Team CostaRica => new Team("Costa Rica");
        internal static Team Serbia => new Team("Serbia");
        internal static Team Germany => new Team("Germany");
        internal static Team Mexico => new Team("Mexico");
        internal static Team Sweden => new Team("Sweden");
        internal static Team SouthKorea => new Team("South Korea");
        internal static Team Belgium => new Team("Belgium");
        internal static Team Panama => new Team("Panama");
        internal static Team Tunisia => new Team("Tunisia");
        internal static Team England => new Team("England");
        internal static Team Colombia => new Team("Colombia");
        internal static Team Japan => new Team("Japan");
        internal static Team Poland => new Team("Poland");
        internal static Team Senegal => new Team("Senegal");
    }
}
