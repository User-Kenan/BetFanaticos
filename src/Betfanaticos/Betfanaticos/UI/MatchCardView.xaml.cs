using Betfanaticos.domain;
using Betfanaticos.UI;
using Serilog;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Betfanaticos
{
    public partial class MatchCardView : UserControl
    {
        private Match? currentMatch;
        private User currentUser;
        private Action updateCoinsDisplay;

        public MatchCardView(User user, Action updateCoins)
        {
            InitializeComponent();

            currentUser = user;
            updateCoinsDisplay = updateCoins;
        }

        public void DisplayMatch(Match match)
        {
            Log.Information("Match wird angezeigt");

            currentMatch = match;

            TeamsText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";
            DateText.Text = match.MatchDate.ToString("dd.MM.yyyy HH:mm");
        }

        private void BetButton_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Wettfenster wird geöffnet");

            if (currentMatch == null)
            {
                Log.Error("Kein Match verfügbar");
                return;
            }

            BetWindow betWindow = new BetWindow(currentMatch, currentUser, updateCoinsDisplay);
            betWindow.ShowDialog();
        }
    }
}