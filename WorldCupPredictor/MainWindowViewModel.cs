using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using WorldCupPredictor.Data;

namespace WorldCupPredictor
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<MatchDay> _matchDays;
        private ObservableCollection<Group> _groups;
        private string _name;

        public MainWindowViewModel()
        {
            this.random = new Random(DateTime.Now.Millisecond);
            this.MatchDays = new ObservableCollection<MatchDay>(MatchesHelper.GetAllMatchDays());
            this.Groups = new ObservableCollection<Group>(MatchesHelper.GetAllGroups());

            this.SubmitCommand = new DelegateCommand(this.OnSubmit, this.CanSubmit).ObservesProperty(() => this.MatchDays);
            this.GenerateCommand = new DelegateCommand(this.OnGenerate);
        }

        private void OnGenerate()
        {
            foreach(var match in this.MatchDays.SelectMany(matchDay => matchDay.Matches))
            {
                match.HomeScoreString = this.random.Next(0, 5).ToString();
                match.AwayScoreString = this.random.Next(0, 5).ToString();
            }
        }

        private bool CanSubmit()
        {
            var allMatches = this.MatchDays.SelectMany(matchDay => matchDay.Matches);
            return true;
            //return !allMatches.Any(match => match.Result == Result.NotPlayed) &&
            //       !string.IsNullOrWhiteSpace(this.Name);
        }

        private void OnSubmit()
        {
            var allMatches = this.MatchDays.SelectMany(matchDay => matchDay.Matches);
            var predictions = new Predictions(allMatches, this.Groups);
            var filePath = Path.Combine(GetExecutingAssemblyDirectory(), $"{this.Name}.json");

            var output = JsonConvert.SerializeObject(predictions, Formatting.Indented);
            File.WriteAllText(filePath, output);

            var deserializedPredictions = JsonConvert.DeserializeObject<Predictions>(File.ReadAllText(filePath));
            MessageBox.Show($"Congratulations {this.Name}, your predictions have been submitted.");
        }

        public string Name
        {
            get => this._name;
            set => this.SetProperty(ref this._name, value);
        }

        public static string GetExecutingAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private Random random;

        public ObservableCollection<MatchDay> MatchDays
        {
            get => this._matchDays;
            set => this.SetProperty(ref this._matchDays, value);
        }

        public ObservableCollection<Group> Groups
        {
            get => this._groups;
            set => this.SetProperty(ref this._groups, value);
        }

        public DelegateCommand SubmitCommand { get; }
        public DelegateCommand GenerateCommand { get; }
    }
}
