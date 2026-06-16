using Betfanaticos.data.models;
using Betfanaticos.domain;
using System.Windows;
using System.Xml.Linq;
using Betfanaticos.data.Services;
using System.Net.Http;
using static AuthServiceREST;

namespace Betfanaticos.UI
{
    public partial class Login : Window
    {

        private readonly IAuthServiceRest authService;

        public Login()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            authService = new AuthServiceREST(client);
        }

        // Ki prompt : Siehe AuthServiceREST
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new LoginRequest // Request wird an diese TExtböxe angebunden
                {
                    name = txtUsername.Text,
                    password = txtPassword.Password
                };

                var result = await authService.Login(request); // Login methode wird mit request Body aufgerugen an server geschcikt dann

                SessionService.SetUser(result);


                Mainwindow mainwindow = new Mainwindow();
                mainwindow.Show();


            }
            catch (Exception ex) // Falls ein fehler auftaucht
            {
                MessageBox.Show("Login fehlgeschlagen: " + ex.Message);
            }
        }
    

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            WindowCreateAcc registerWindow = new WindowCreateAcc();
            registerWindow.Show();
        }

    }
}