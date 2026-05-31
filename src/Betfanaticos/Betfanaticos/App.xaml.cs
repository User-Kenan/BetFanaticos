using Betfanaticos.domain;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Betfanaticos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AuthService AuthService { get; } = new AuthService();
    }

}
