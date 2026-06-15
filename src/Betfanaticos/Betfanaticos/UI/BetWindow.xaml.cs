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
        private User currentUser;

        public BetWindow(Match selectedMatch, User user)
        {
            InitializeComponent();

            match = selectedMatch;
            currentUser = user;

            MatchText.Text = $"{match.HomeTeam} vs {match.AwayTeam}";
            HomeTeamRadio.Content = match.HomeTeam;
            AwayTeamRadio.Content = match.AwayTeam;



        }

        private void SaveBet_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AmountTextBox.Text, out int amount))
            {
                MessageBox.Show("Bitte gültigen Betrag eingeben.");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Betrag muss größer als 0 sein.");
                return;
            }

            string prediction;

            if (HomeTeamRadio.IsChecked == true)
                prediction = HomeTeamRadio.Content.ToString();
            else if (AwayTeamRadio.IsChecked == true)
                prediction = AwayTeamRadio.Content.ToString();
            else
            {
                MessageBox.Show("Bitte ein Team auswählen.");
                return;
            }

            if (currentUser.Coins < amount)
            {
                MessageBox.Show("Du hast nicht genug Coins.");
                return;
            }

            currentUser.RemoveCoins(amount);

            Bet bet = new Bet(
                currentUser.Id,
                match.Id,
                amount,
                prediction
            );

            MessageBox.Show($"Wette platziert!\nNeue Coins: {currentUser.Coins}");

            Close();

        }
    }
}
