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
        private readonly Action updateCoinsDisplay;

        private readonly IBetService betService = new FakeBetService();
        private readonly CoinStorageService coinStorage = new CoinStorageService();

        public BetWindow(Match selectedMatch, User user, Action updateCoins)
        {
            InitializeComponent();

            match = selectedMatch;
            currentUser = user;
            updateCoinsDisplay = updateCoins;

            MatchText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";
            HomeTeamRadio.Content = match.HomeTeam;
            AwayTeamRadio.Content = match.AwayTeam;
        }

        private async void SaveBet_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Wette wird gespeichert");

            if (!int.TryParse(AmountTextBox.Text, out int amount))
            {
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

                if (match.HomeScore > match.AwayScore)
                {
                    string winner = match.HomeTeam;

                    int wonCoins = bet.CalculateResult(winner);
                    currentUser.AddCoins(wonCoins);
                }
                else if (match.AwayScore > match.HomeScore)
                {
                    string winner = match.AwayTeam;

                    int wonCoins = bet.CalculateResult(winner);
                    currentUser.AddCoins(wonCoins);
                }
                else
                {
                    bet.Status = BetStatus.Lost;
                }

                WalletServiceREST walletService = new WalletServiceREST();
                await walletService.UpdateWalletByUserId(currentUser.Id, currentUser.Coins);

                updateCoinsDisplay();

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