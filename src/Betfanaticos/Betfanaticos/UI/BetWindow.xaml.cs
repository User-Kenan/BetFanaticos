using Betfanaticos.data.Services;
using Betfanaticos.domain;
using Serilog;
using System;
using System.Net.Http;
using System.Windows;

namespace Betfanaticos.UI
{
    public partial class BetWindow : Window
    {
        private readonly Match match;
        private readonly User currentUser;
        private readonly Action updateCoinsDisplay;

        private readonly IBetService betService;
        private readonly bool useFakeService = false;

        public BetWindow(Match selectedMatch, User user, Action updateCoins)
        {
            InitializeComponent();

            match = selectedMatch;
            currentUser = user;
            updateCoinsDisplay = updateCoins;

            if (useFakeService)
            {
                betService = new FakeBetService();
            }
            else
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/")
                };

                betService = new BetServiceREST(client);
            }

            MatchText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";

            HomeTeamRadio.Content = $"{match.HomeTeam} | Quote: {match.HomeOdds}";
            DrawRadio.Content = $"Unentschieden | Quote: {match.DrawOdds}";
            AwayTeamRadio.Content = $"{match.AwayTeam} | Quote: {match.AwayOdds}";
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
            double selectedOdds;

            if (HomeTeamRadio.IsChecked == true)
            {
                prediction = match.HomeTeam;
                selectedOdds = match.HomeOdds;
            }
            else if (DrawRadio.IsChecked == true)
            {
                prediction = "Draw";
                selectedOdds = match.DrawOdds;
            }
            else if (AwayTeamRadio.IsChecked == true)
            {
                prediction = match.AwayTeam;
                selectedOdds = match.AwayOdds;
            }
            else
            {
                MessageBox.Show("Bitte ein Team auswählen.");
                return;
            }

            try
            {
                Bet bet = await betService.PlaceBet(
                    currentUser,
                    match,
                    amount,
                    prediction,
                    selectedOdds
                );

                if (useFakeService)
                {
                    WalletServiceREST fakeWalletService = new WalletServiceREST();
                    await fakeWalletService.UpdateWalletByUserId(currentUser.Id, currentUser.Coins);
                }

                await SessionService.ChallangeManager.UpdateAsync(
                    EnumChallangeType.PlacePrediction,
                    1
                );

                await SessionService.ChallangeManager.LoadChallengesAsync();
                await SessionService.ReloadCoinsAsync();

                if (match.Status != "Finished")
                {
                    updateCoinsDisplay();

                    MessageBox.Show(
                        $"Wette wurde gespeichert.\n" +
                        $"Das Spiel ist noch nicht beendet.\n" +
                        $"Neue Coins: {currentUser.Coins}"
                    );

                    Close();
                    return;
                }

                string winner;

                if (match.HomeScore > match.AwayScore)
                {
                    winner = match.HomeTeam;
                }
                else if (match.AwayScore > match.HomeScore)
                {
                    winner = match.AwayTeam;
                }
                else
                {
                    winner = "Draw";
                }

                if (prediction == winner)
                {
                    bet.Status = BetStatus.Won;

                    int wonCoins = (int)(amount * selectedOdds);
                    currentUser.AddCoins(wonCoins);

                    WalletServiceREST walletService = new WalletServiceREST();
                    await walletService.UpdateWalletByUserId(currentUser.Id, currentUser.Coins);

                    await SessionService.ChallangeManager.UpdateAsync(
                        EnumChallangeType.CorrectPrediction,
                        1
                    );

                    await SessionService.ChallangeManager.LoadChallengesAsync();
                    await SessionService.ReloadCoinsAsync();

                    updateCoinsDisplay();

                    MessageBox.Show(
                        $"Wette gewonnen!\n" +
                        $"Gewinn: {wonCoins}\n" +
                        $"Neue Coins: {currentUser.Coins}"
                    );
                }
                else
                {
                    bet.Status = BetStatus.Lost;

                    await SessionService.ReloadCoinsAsync();

                    updateCoinsDisplay();

                    MessageBox.Show(
                        $"Wette verloren!\n" +
                        $"Neue Coins: {currentUser.Coins}"
                    );
                }

                Log.Information("Wette erfolgreich platziert");

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