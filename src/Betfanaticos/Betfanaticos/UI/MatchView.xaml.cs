using Betfanaticos.data.Services;
using Betfanaticos.domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Betfanaticos
{
    public partial class MatchView : UserControl
    {
        private string sport;
        private User currentUser;
        private Action updateCoinsDisplay;

        public MatchView(string sportType, User user, Action updateCoins)
        {
            InitializeComponent();

            sport = sportType;
            currentUser = user;
            updateCoinsDisplay = updateCoins;

            Log.Information("MatchView geöffnet für Sportart: {Sport}", sport);

            LoadMatches();
        }

        public async void LoadMatches()
        {
            ApiService api = new ApiService();
            List<Match> matches;

            Log.Information("Matches werden geladen für Sportart: {Sport}", sport);

            if (sport == "Basketball")
            {
                matches = await api.GetBasketballMatchesAsync();
            }
            else if (sport == "Football")
            {
                matches = await api.GetFootballMatchesAsync();
            }
            else
            {
                matches = await api.GetBaseballMatchesAsync();
            }

            Log.Information("Matches erfolgreich geladen");

            DisplayMatches(MatchesPanel, matches);
        }

        private void DisplayMatches(StackPanel panel, List<Match> matches)
        {
            panel.Children.Clear();

            Log.Information("Match Cards werden angezeigt");

            foreach (Match match in matches)
            {
                MatchCardView card = new MatchCardView(currentUser, updateCoinsDisplay);
                card.DisplayMatch(match);

                panel.Children.Add(card);
            }
        }
    }
}