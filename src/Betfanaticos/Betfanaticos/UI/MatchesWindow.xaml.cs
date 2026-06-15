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
    /// Interaktionslogik für MatchesWindow.xaml
    /// </summary>
    public partial class MatchesWindow : Window
    {
        public MatchesWindow()
        {
            InitializeComponent();

            MainContent.Content = new MatchView("Football");
        }

        private void Games_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MatchView("Football");
        }

        private void Basketball_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MatchView("Basketball");
        }

        

        private void MLB_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MatchView("Baseball");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Mainwindow main = new Mainwindow();
            main.Show();

            this.Close();
        }
    }
}
