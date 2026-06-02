using Betfanaticos.domain;
using System.Windows;

namespace Betfanaticos.UI
{
    public partial class Login : Window
    {
        private AuthService authservice;

        public Login()
        {
            InitializeComponent();
            authservice = new AuthService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string input_name = txtUsername.Text;
            string input_password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(input_name) ||
                string.IsNullOrWhiteSpace(input_password))
            {
                MessageBox.Show("Bitte alle Felder ausfüllen");
                return;
            }

            var user = App.AuthService.Login(input_name, input_password);

            if(user == EnumLoginResponse.UserNotFound)
            {
                MessageBox.Show("Dieser User Existiert nicht");
                return;
            }

            if(user == EnumLoginResponse.WrongPassword)
            {
                MessageBox.Show("Falsches Passwort");
                return;
            }

            if(user == EnumLoginResponse.Success)
            {
                Mainwindow mainwindow = new Mainwindow();
                mainwindow.Show();
            }

           

            

            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            WindowCreateAcc registerWindow = new WindowCreateAcc();
            registerWindow.Show();
        }
    }
}