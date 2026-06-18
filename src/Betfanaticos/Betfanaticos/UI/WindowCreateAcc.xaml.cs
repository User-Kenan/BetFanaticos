using Betfanaticos.data.models;
using Betfanaticos.data.Services;
using System;
using System.Net.Http;
using System.Windows;

namespace Betfanaticos.UI
{
    public partial class WindowCreateAcc : Window
    {
        private readonly IAuthServiceRest authService;

        public WindowCreateAcc()
        {
            InitializeComponent();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };

            authService = new AuthServiceREST(client);
        }

        private async void Button_Create_acc(object sender, RoutedEventArgs e)
        {
            try
            {
                var request = new UserCreate
                {
                    name = Textbox_Name.Text,
                    password = Textbox_Password.Password
                };

                await authService.Register(request);

                MessageBox.Show("Account erfolgreich erstellt.");

                Login login = new Login();
                login.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Register fehlgeschlagen: " + ex.Message);
            }
        }
    }
}