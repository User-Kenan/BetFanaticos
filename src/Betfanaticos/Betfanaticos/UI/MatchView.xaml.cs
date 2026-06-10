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
using Betfanaticos.domain;

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

            InitializeComponent();
            sport = sportType;
            LoadMatches();
        }

        
        public async void LoadMatches()
        {
            ApiService api = new ApiService();

            List<Match> matches;

            if (sport == "Basketball")
            {
                TitleText.Text = "🏀 Basketball";
                matches = await api.GetBasketballMatchesAsync();
            }
            else
            {
                TitleText.Text = "⚽ Football";
                matches = await api.GetFootballMatchesAsync();
            }

            DisplayMatches(MatchesPanel, matches);


        }

        // Baut die Oberfläche aus 
        private void DisplayMatches(StackPanel panel, List<Match> matches)
        {
            panel.Children.Clear();

            foreach (Match match in matches)
            {
                MatchCardView card = new MatchCardView();
                card.DisplayMatch(match);

                panel.Children.Add(card);
            }
        }
    }
}
