using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorldCupPredictor.Data;

namespace WorldCupPredictor
{
    public class MainWindowViewModel : BindableBase
    {
        private List<IEnumerable<Match>> _matchDays;

        public MainWindowViewModel()
        {
            this.MatchDays = new List<IEnumerable<Match>>(MatchesHelper.GetAllMatchDays());
        }

        public List<IEnumerable<Match>> MatchDays
        {
            get => this._matchDays;
            set => this.SetProperty(ref this._matchDays, value);
        }

    }
}
