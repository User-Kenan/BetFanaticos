using Betfanaticos.domain;
using Betfanaticos.UI;
using Serilog;
using System;
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
    /// Interaktionslogik für MatchCardView.xaml
    /// </summary>
    public partial class MatchCardView : UserControl
    {
        

        public MatchCardView()
        {
            InitializeComponent();
        }

        private Match? currentMatch;
        private User currentUser;

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
                Log.Error("Keine Matche verfügbar");
                return;
            }
                

            BetWindow betWindow = new BetWindow(currentMatch, currentUser);
            betWindow.ShowDialog();
        }
    }
}
