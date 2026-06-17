using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuthServiceREST;

namespace Betfanaticos.domain
{
    public class ChallangeManager
    {
       
        public List<Challenge> Challenges { get; } = new();

        public void AddChallenge(Challenge challenge)
        {
            Challenges.Add(challenge);
        }

        public void Update(EnumChallangeType type, int amount)
        {
            foreach (var c in Challenges)
            {
                if(c.ChallengeType == type)
                {
                    c.UpdateProgress(amount);

                    if (c.IsComplete() && !c.RewardClaimed)
                    {
                        User.Curren.AddCoins(c.Reward);
                        c.ClaimReward();
                        Log.Information("Challenge abgeschlossen: {Title}", c.Title);
                    }
                }
            }
        }

        private void SeedDefaultChallenges()
        {
            Challenges.Add(new Challenge(
                1,
                "Daily Login",
                "Logge dich einmal ein",
                EnumChallangeType.DailyLogin,
                1,
                25
            ));

            Challenges.Add(new Challenge(
                2,
                "3 Predictions",
                "Gib 3 Predictions ab",
                EnumChallangeType.PlacePrediction,
                3,
                100
            ));

            Challenges.Add(new Challenge(
                3,
                "Lucky Prediction",
                "Treffe 1 richtige Prediction",
                EnumChallangeType.CorrectPrediction,
                1,
                50
            ));
        }


    }
}
