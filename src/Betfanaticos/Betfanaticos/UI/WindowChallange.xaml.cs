using Betfanaticos.data.Services;
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
using static AuthServiceREST;

namespace Betfanaticos.UI
{
    /// <summary>
    /// Interaction logic for WindowChallange.xaml
    /// </summary>
    public partial class WindowChallange : Window
    {

        public WindowChallange()
        {
            InitializeComponent();

           
         

            LoadChallenges();
        }

   

        private Task LoadChallenges()
        {
            Log.Information("Challenges werden geladen");

            ChallengesPanel.Children.Clear();

            foreach (var challenge in SessionService.ChallangeManager.Challenges)
            {
                ChallengesPanel.Children.Add(
                    new ChallengeCardView(challenge)
                );
            }

            Log.Information("Challenges erfolgreich geladen");



            return Task.CompletedTask;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Zurück zum Hauptmenü");

            Mainwindow main = new Mainwindow();
            main.Show();

            this.Close();
        }
    }
}

