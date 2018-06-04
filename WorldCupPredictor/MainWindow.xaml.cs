using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WorldCupPredictor.Data;

namespace WorldCupPredictor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void OnEnteringScore(object sender, KeyboardFocusChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            var presenter = (ContentPresenter)textbox.TemplatedParent;
            var match = (Match)presenter.Content;

            this.GroupsListView.ScrollIntoView(match.TeamHome.Group);
        }
    }
}
