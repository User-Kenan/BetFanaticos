using Betfanaticos.data.models;
using Betfanaticos.domain;
using System.Windows;
using System.Xml.Linq;
using Betfanaticos.data.Services;
using System.Net.Http;
using static Betfanaticos.data.Services.SessionService;
using System.IO;

namespace Betfanaticos.UI
{
    public partial class Login : Window
    {

        private readonly IAuthServiceRest authService;
        bool useFakeService = false;
        public Login()
        {
            InitializeComponent();

       
            if (useFakeService)
            {
                authService = new FakeAuthService();
            }
            else
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/")
                };

                authService = new AuthServiceREST(client);
            }
        }

        // Ki prompt : Siehe AuthServiceREST
        private async void btnLogin_Click(object sender, EventArgs e)
        {
          
            try
            {
                // Erstellt das Request-Objekt aus den Eingaben des Benutzers.
                var request = new LoginRequest
                {
                    name = txtUsername.Text,
                    password = txtPassword.Password
                };

                // Führt den Login über den gewählten Service aus.
                // Je nach Einstellung wird entweder die REST-API
                // oder der Fake-Service verwendet.
                var result = await authService.Login(request);

                // Speichert die Benutzerdaten global für die aktuelle Sitzung.
                SessionService.SetUserAsync(result);

                await SessionService.ChallangeManager.LoadChallengesAsync();

                await SessionService.ChallangeManager.UpdateAsync(
                    EnumChallangeType.DailyLogin,
                    1
                );

                await SessionService.SetUserAsync(result);

                await SessionService.ChallangeManager.UpdateAsync(
                    EnumChallangeType.DailyLogin,
                    1
                );

                await SessionService.ReloadCoinsAsync();


                // Öffnet das Hauptfenster nach erfolgreichem Login.
                Mainwindow mainwindow = new Mainwindow();
                mainwindow.Show();

                // Schließt das Login-Fenster.
                this.Close();
            }
            catch (Exception ex)
            {
                // Zeigt mögliche Fehler dem Benutzer an.
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