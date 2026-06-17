using Betfanaticos.data.Services;
using Betfanaticos.domain;
using Serilog;
using System.Windows;
using static AuthServiceREST;

namespace Betfanaticos.UI
{
    public partial class MatchesWindow : Window
    {
        private User currentUser;
        private CoinStorageService coinStorage = new CoinStorageService();

        public MatchesWindow()
        {
            InitializeComponent();

            currentUser = SessionService.CurrentUser;

            coinStorage.LoadCoins(currentUser);

            UpdateCoinsDisplay();

            MainContent.Content = new MatchView("Football", currentUser, UpdateCoinsDisplay);
        }

        private void UpdateCoinsDisplay()
        {
            CoinsText.Text = $"$ {currentUser.Coins}";
        }

        private void Games_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Fusballspiele werden geladen");
            MainContent.Content = new MatchView("Football", currentUser, UpdateCoinsDisplay);
        }

        private void Basketball_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Basketballspiele werden geladen");
            MainContent.Content = new MatchView("Basketball", currentUser, UpdateCoinsDisplay);
        }

        private void MLB_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Baseballspiele werden geladen");
            MainContent.Content = new MatchView("Baseball", currentUser, UpdateCoinsDisplay);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Zurück zum Hauptmenü");

            coinStorage.SaveCoins(currentUser);

            Mainwindow main = new Mainwindow();
            main.Show();

            this.Close();
        }
    }
}