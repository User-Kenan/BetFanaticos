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

namespace Betfanaticos
{
    /// <summary>
    /// Interaktionslogik für MatchView.xaml
    /// </summary>
    public partial class MatchView : UserControl
    {
        private string sport;
        public MatchView(string sportType)
        {
            InitializeComponent();

            Log.Information("MatchView geöffnet für Sportart: {Sport}", sport);
            sport = sportType;
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

        // Baut die Oberfläche aus 
        private void DisplayMatches(StackPanel panel, List<Match> matches)
        {
            panel.Children.Clear();
            Log.Information("Match Cards werden angezeigt");
            foreach (Match match in matches)
            {
                MatchCardView card = new MatchCardView();
                card.DisplayMatch(match);

                panel.Children.Add(card);
            }
        }
    }
}
