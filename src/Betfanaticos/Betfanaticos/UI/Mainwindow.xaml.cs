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

namespace Betfanaticos.UI
{
    /// <summary>
    /// Interaction logic for Mainwindow.xaml
    /// </summary>
    public partial class Mainwindow : Window
    {
        public Mainwindow()
        {
            InitializeComponent();

        }

        

        private void Matches_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Matches Fenster öffnen");
            MatchesWindow matchesWindow = new MatchesWindow();
            matchesWindow.Show();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Challenges_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Challenge Fenster öffnen");
            WindowChallange windowChallange = new WindowChallange();
            windowChallange.Show();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Application beenden");
            Application.Current.Shutdown();
        }

       
    }
}
            