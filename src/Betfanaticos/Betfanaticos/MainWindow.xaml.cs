using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Betfanaticos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new MatchView();
        }

     

       

        private void Games_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MatchView();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
