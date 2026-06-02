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
    /// Interaktionslogik für MatchCardView.xaml
    /// </summary>
    public partial class MatchCardView : UserControl
    {
        public MatchCardView()
        {
            InitializeComponent();
        }

        public void DisplayMatch(Match match)
        {
            TeamsText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";

            DateText.Text = match.MatchDate.ToString("dd.MM.yyyy HH:mm");
        }
    }
}
