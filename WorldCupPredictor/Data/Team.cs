using Prism.Mvvm;
using System;

namespace WorldCupPredictor.Data
{
    public class Team : BindableBase
    {
        private uint _won;

        private uint _drawn;

        private uint _lost;

        private uint _goalsScored;

        private uint _goalsConceded;

        private int _goalDifference;

        private uint _points;

        private Team()
        {
        }

        internal Team(string name)
        {
            this.Name = name;
        }

        public string ImagePath => $@"\Flags\{Name}.png";

        public string Name { get; }

        public Group Group { get; set; }

        public uint Won
        {
            get => this._won;
            set => this.SetProperty(ref this._won, value);
        }


        public uint Drawn
        {
            get => this._drawn;
            set => this.SetProperty(ref this._drawn, value);
        }

        public uint Lost
        {
            get => this._lost;
            set => this.SetProperty(ref this._lost, value);
        }

        public uint GoalsScored
        {
            get => this._goalsScored;
            set
            {
                this.SetProperty(ref this._goalsScored, value);
                this.GoalDifference = (int)this.GoalsScored - (int)this.GoalsConceded;
            }
            
        }

        public uint GoalsConceded
        {
            get => this._goalsConceded;
            set
            {
                this.SetProperty(ref this._goalsConceded, value);
                this.GoalDifference = (int)this.GoalsScored - (int)this.GoalsConceded;
            }
        }

        public uint Points
        {
            get => this._points;
            set => this.SetProperty(ref this._points, value);
        }

        public int GoalDifference
        {
            get => this._goalDifference;
            set => this.SetProperty(ref this._goalDifference, value);
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }

        internal void Reset()
        {
            this.Won = 0;
            this.Drawn = 0;
            this.Lost = 0;
            this.GoalsScored = 0;
            this.GoalsConceded = 0;
            this.Points = 0;
        }
    }

    public class Teams
    {
        private static Teams instance = null;
        private Team russia;
        private Team saudiArabia;
        private Team egypt;
        private Team uruguay;
        private Team portugal;
        private Team spain;
        private Team morocco;
        private Team iran;
        private Team france;
        private Team australia;
        private Team peru;
        private Team denmark;
        private Team argentina;
        private Team iceland;
        private Team croatia;
        private Team nigeria;
        private Team brazil;
        private Team switzerland;
        private Team costaRica;
        private Team serbia;
        private Team germany;
        private Team mexico;
        private Team sweden;
        private Team southKorea;
        private Team belgium;
        private Team panama;
        private Team tunisia;
        private Team england;
        private Team colombia;
        private Team japan;
        private Team poland;
        private Team senegal;

        private Teams()
        {
            this.russia = new Team("Russia");
            this.saudiArabia = new Team("Saudi Arabia");
            this.egypt = new Team("Egypt");
            this.uruguay = new Team("Uruguay");
            this.portugal = new Team("Portugal");
            this.spain = new Team("Spain");
            this.morocco = new Team("Morocco");
            this.iran = new Team("Iran");
            this.france = new Team("France");
            this.australia = new Team("Australia");
            this.peru = new Team("Peru");
            this.denmark = new Team("Denmark");
            this.argentina = new Team("Argentina");
            this.iceland = new Team("Iceland");
            this.croatia = new Team("Croatia");
            this.nigeria = new Team("Nigeria");
            this.brazil = new Team("Brazil");
            this.switzerland = new Team("Switzerland");
            this.costaRica = new Team("Costa Rica");
            this.serbia = new Team("Serbia");
            this.germany = new Team("Germany");
            this.mexico = new Team("Mexico");
            this.sweden = new Team("Sweden");
            this.southKorea = new Team("South Korea");
            this.belgium = new Team("Belgium");
            this.panama = new Team("Panama");
            this.tunisia = new Team("Tunisia");
            this.england = new Team("England");
            this.colombia = new Team("Colombia");
            this.japan = new Team("Japan");
            this.poland = new Team("Poland");
            this.senegal = new Team("Senegal");
        }

        internal static Teams Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Teams();
                }

                return instance;
            }
        }

        internal static Team Russia => Instance.russia;
        internal static Team SaudiArabia => Instance.saudiArabia;
        internal static Team Egypt => Instance.egypt;
        internal static Team Uruguay => Instance.uruguay;
        internal static Team Portugal => Instance.portugal;
        internal static Team Spain => Instance.spain;
        internal static Team Morocco => Instance.morocco;
        internal static Team Iran => Instance.iran;
        internal static Team France => Instance.france;
        internal static Team Australia => Instance.australia;
        internal static Team Peru => Instance.peru;
        internal static Team Denmark => Instance.denmark;
        internal static Team Argentina => Instance.argentina;
        internal static Team Iceland => Instance.iceland;
        internal static Team Croatia => Instance.croatia;
        internal static Team Nigeria => Instance.nigeria;
        internal static Team Brazil => Instance.brazil;
        internal static Team Switzerland => Instance.switzerland;
        internal static Team CostaRica => Instance.costaRica;
        internal static Team Serbia => Instance.serbia;
        internal static Team Germany => Instance.germany;
        internal static Team Mexico => Instance.mexico;
        internal static Team Sweden => Instance.sweden;
        internal static Team SouthKorea => Instance.southKorea;
        internal static Team Belgium => Instance.belgium;
        internal static Team Panama => Instance.panama;
        internal static Team Tunisia => Instance.tunisia;
        internal static Team England => Instance.england;
        internal static Team Colombia => Instance.colombia;
        internal static Team Japan => Instance.japan;
        internal static Team Poland => Instance.poland;
        internal static Team Senegal => Instance.senegal;
    }
}
