using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorldCupPredictor.Data;

namespace WorldCupPredictor
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<MatchDay> _matchDays;
        private ObservableCollection<Group> _groups;

        public MainWindowViewModel()
        {
            this.MatchDays = new ObservableCollection<MatchDay>(MatchesHelper.GetAllMatchDays());
            this.Groups = new ObservableCollection<Group>(MatchesHelper.GetAllGroups());
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
    }
}
