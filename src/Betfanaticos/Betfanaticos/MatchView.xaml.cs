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
        public MatchView()
        {
            InitializeComponent();

            LoadMatches();
        }

        
        public async void LoadMatches()
        {
            ApiService api = new ApiService();
            List<Match> footballMatches = await api.GetFootballMatchesAsync();
            DisplayMatches(FootballPanel, footballMatches);
        }

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
