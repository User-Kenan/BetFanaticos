using Betfanaticos.domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Betfanaticos.UI
{
    /// <summary>
    /// Interaction logic for WindowChallange.xaml
    /// </summary>
    public partial class WindowChallange : Window
    {
        private readonly ApiService apiService = new();

        public WindowChallange()
        {
            InitializeComponent();
            Log.Information("Challenge Fenster geöffnet");
            LoadChallenges();
        }

        private async void LoadChallenges()
        {
            Log.Information("Challenges werden geladen");
            var challenges = await apiService.GetSidequestsAsync();

            ChallengesPanel.Children.Clear();

            foreach (var challenge in challenges)
            {
                ChallengeCardView card = new ChallengeCardView(challenge);
                ChallengesPanel.Children.Add(card);
            }
            Log.Information("Challenges erfolgreich geladen");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Zurück zum Hauptmenü");
            Mainwindow main = new Mainwindow();
            main.Show();

            this.Close();
        }
    }
}
