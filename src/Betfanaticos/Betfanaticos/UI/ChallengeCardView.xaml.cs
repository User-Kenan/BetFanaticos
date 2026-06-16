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
        public ChallengeCardView(ChallengeDto challenge)
        {
            InitializeComponent();

            TitleText.Text = challenge.challange;
            DescriptionText.Text = challenge.description;

            ProgressBarChallenge.Maximum = challenge.required_amount;
            ProgressBarChallenge.Value = challenge.current_state;

            ProgressText.Text =
                $"{challenge.current_state}/{challenge.required_amount}";

            RewardText.Text =
                $"Belohnung: {challenge.earned_coins} Coins";
        }
    }
}
