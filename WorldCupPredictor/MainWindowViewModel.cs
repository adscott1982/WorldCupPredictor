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
        private readonly Random _random;


        public MainWindowViewModel()
        {
            this._random = new Random(DateTime.Now.Millisecond);
            this.MatchDays = new ObservableCollection<MatchDay>(MatchesHelper.GetAllMatchDays());
            this.Groups = new ObservableCollection<Group>(MatchesHelper.GetAllGroups());

            this.SubmitCommand = new DelegateCommand(this.OnSubmit, this.CanSubmit)
                .ObservesProperty(() => this.MatchDays)
                .ObservesProperty(() => this.Name);
            this.GenerateCommand = new DelegateCommand(this.OnGenerate);
        }

        private void OnGenerate()
        {
            foreach(var match in this.MatchDays.SelectMany(matchDay => matchDay.Matches))
            {
                match.HomeScoreString = this._random.Next(0, 5).ToString();
                match.AwayScoreString = this._random.Next(0, 5).ToString();
            }
        }

        private bool CanSubmit()
        {
            var allMatches = this.MatchDays.SelectMany(matchDay => matchDay.Matches);
            
            return allMatches.All(match => match.Result != Result.NotPlayed) 
                && !string.IsNullOrWhiteSpace(this.Name);
        }

        private void OnSubmit()
        {
            var allMatches = this.MatchDays.SelectMany(matchDay => matchDay.Matches);
            var predictions = new Predictions(allMatches, this.Groups);
            var directory = Path.Combine(GetExecutingAssemblyDirectory(), "Predictions");
            Directory.CreateDirectory(directory);
            var filePath = Path.Combine(directory, $"{this.Name}.json");

            var output = JsonConvert.SerializeObject(predictions, Formatting.Indented);

            try
            {
                File.WriteAllText(filePath, output);

                MessageBox.Show($"Well done {this.Name}, your submission was successful. \n\n" +
                                $"You have successfully pressed the number keys on your computer in a seemingly random order. " +
                                $"Good luck! Let's see if you can beat an octopus.\n\n" +
                                $"Cem and Andy and any other members of the organising committee will be in touch in due course.\n\n" +
                                $"The app will now close.", "All done");
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Unable to save your predictions, please contact technical support! (Andy Scott), exception info:\n\n{e.Message}"
                    + $"\n\n The technical bit:\n\n{e.StackTrace}",
                    "Catastrophic Failure!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Environment.Exit(0);
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

            // If it is a network path insert the host name
            if (!string.IsNullOrWhiteSpace(uri.Host))
            {
                path = $@"\\{uri.Host}{path}";
            }

            return Path.GetDirectoryName(path);
        }

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
