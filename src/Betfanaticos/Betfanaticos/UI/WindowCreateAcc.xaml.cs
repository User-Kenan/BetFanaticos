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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Betfanaticos.UI
{
    /// <summary>
    /// Interaction logic for WindowCreateAcc.xaml
    /// </summary>
    public partial class WindowCreateAcc : Window
    {
        public WindowCreateAcc()
        {
            InitializeComponent();
        }

        private void Button_Create_acc(object sender, RoutedEventArgs e)
        {
            string input_username = Textbox_Name.Text;
            string input_password = Textbox_Password.Password;


            if (string.IsNullOrWhiteSpace(input_username))
            {
                MessageBox.Show("Ungültiger Username");
                return;
            }

            if (string.IsNullOrWhiteSpace(input_password))
            {
                MessageBox.Show("Ungültiger Passwort");
                return;
            }

            var user = App.AuthService.Register(input_username, input_password);

            if (user == null)
            {
                MessageBox.Show("Dieser User Existiert bereits");
                return;
            }

            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            
        }

        private void Textbox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
