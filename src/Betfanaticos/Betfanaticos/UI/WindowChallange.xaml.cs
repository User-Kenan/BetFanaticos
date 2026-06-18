using Betfanaticos.data.Services;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Betfanaticos.UI
{
    public partial class WindowChallange : Window
    {
        public WindowChallange()
        {
            InitializeComponent();
            Loaded += WindowChallange_Loaded;
        }

        private async void WindowChallange_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadChallengesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Challenges konnten nicht geladen werden: " + ex.Message);
            }
        }

        private async Task LoadChallengesAsync()
        {
            Log.Information("Challenges werden geladen");

            await SessionService.ChallangeManager.LoadChallengesAsync();

            ChallengesPanel.Children.Clear();

            foreach (var challenge in SessionService.ChallangeManager.Challenges)
            {
                ChallengesPanel.Children.Add(
                    new ChallengeCardView(challenge)
                );
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