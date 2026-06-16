using Betfanaticos.data.models;
using Betfanaticos.domain;
using System.Windows;
using System.Xml.Linq;
using Betfanaticos.data.Services;
using System.Net.Http;

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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new LoginRequest
                {
                    name = txtUsername.Text,
                    password = txtPassword.Password
                };

                var result = await authService.Login(request);

                MessageBox.Show("Login erfolgreich! Role: " + result.user.role);
            }
            catch (Exception ex)
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