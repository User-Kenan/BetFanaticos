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
    /// Interaction logic for Mainwindow.xaml
    /// </summary>
    public partial class Mainwindow : Window
    {
        public Mainwindow()
        {
            
            InitializeComponent();
            LabelUser.Content = App.AuthService.CurrentUser.UserName;
            LabelCredits.Content = App.AuthService.CurrentUser.Coins;

        }

        public void Load_Label()
        {

        }
        

        private void TextBoxBet(object sender, RoutedEventArgs e)
        {
            WindowMatch match = new WindowMatch();
            match.Show();
        }

        private void TextBoxChallange(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxStatistics(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxSettings(object sender, RoutedEventArgs e)
        {

        }
    }
}
