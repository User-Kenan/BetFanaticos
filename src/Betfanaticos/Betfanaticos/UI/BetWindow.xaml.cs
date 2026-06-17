using Betfanaticos.data.Services;
using Betfanaticos.domain;
using Serilog;
using System;
using System.Windows;

namespace Betfanaticos.UI
{
    public partial class BetWindow : Window
    {
        private readonly Match match;
        private readonly User currentUser;
        private readonly IBetService betService = new FakeBetService();

        public BetWindow(Match selectedMatch, User user)
        {
            InitializeComponent();

            match = selectedMatch;
            currentUser = user;

            MatchText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";
            HomeTeamRadio.Content = match.HomeTeam;
            AwayTeamRadio.Content = match.AwayTeam;
        }

        private void SaveBet_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Wette wird gespeichert");

            if (!int.TryParse(AmountTextBox.Text, out int amount))
            {
                Log.Error("Kein gültiger Betrag wurde eingegeben");
                MessageBox.Show("Bitte gültigen Betrag eingeben.");
                return;
            }

            string prediction;

            if (HomeTeamRadio.IsChecked == true)
            {
                prediction = HomeTeamRadio.Content.ToString();
            }
            else if (AwayTeamRadio.IsChecked == true)
            {
                prediction = AwayTeamRadio.Content.ToString();
            }
            else
            {
                MessageBox.Show("Bitte ein Team auswählen.");
                return;
            }

            try
            {
                Bet bet = betService.PlaceBet(
                    currentUser,
                    match,
                    amount,
                    prediction
                );

                Log.Information("Wette erfolgreich platziert");

                MessageBox.Show($"Wette platziert!\nNeue Coins: {currentUser.Coins}");
                Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Fehler beim Platzieren der Wette");
                MessageBox.Show(ex.Message);
            }
        }
    }
}