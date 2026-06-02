using Betfanaticos.domain;
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


namespace Betfanaticos.UI
{
    /// <summary>
    /// Interaktionslogik für BetWindow.xaml
    /// </summary>
    public partial class BetWindow : Window
    {
        private readonly Match match;

        public BetWindow(Match selectedMatch)
        {
            InitializeComponent();

            match = selectedMatch;

            MatchText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";
            HomeTeamRadio.Content = match.HomeTeam;
            AwayTeamRadio.Content = match.AwayTeam;



        }

        private void SaveBet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
