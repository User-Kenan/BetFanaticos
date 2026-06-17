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
using Betfanaticos.domain;

namespace Betfanaticos.UI
{
    /// <summary>
    /// Interaktionslogik für ChallengeCardView.xaml
    /// </summary>
    public partial class ChallengeCardView : UserControl
    {
        private readonly Challenge _challange;
        public ChallengeCardView(Challenge challenge)
        {
            InitializeComponent();

            _challange = challenge;

            TitleText.Text = challenge.Title;
            DescriptionText.Text = challenge.Description;

            ProgressText.Text =
                $"{challenge.CurrentState}/{challenge.RequiredAmount}";

        }
    }
}
