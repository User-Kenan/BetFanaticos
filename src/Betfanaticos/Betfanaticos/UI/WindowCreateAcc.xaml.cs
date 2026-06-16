using Betfanaticos.data.models;
using Betfanaticos.data.Services;
using Betfanaticos.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly IAuthServiceRest authService;

        public WindowCreateAcc()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
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

                var result = await authService.Register(request);

            

                Login login = new Login();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Register fehlgeschlagen: " + ex.Message);
            }
        }

      
    }
}
