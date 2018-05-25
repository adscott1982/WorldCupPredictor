using Prism.Mvvm;
using System.Collections.Generic;
using WorldCupPredictor.Data;

namespace WorldCupPredictor
{
    public class MainWindowViewModel : BindableBase
    {
        private List<MatchDay> _matchDays;

        public MainWindowViewModel()
        {
            this.MatchDays = new List<MatchDay>(MatchesHelper.GetAllMatchDays());
        }

        public List<MatchDay> MatchDays
        {
            get => this._matchDays;
            set => this.SetProperty(ref this._matchDays, value);
        }

    }
}
