using Betfanaticos.domain;

namespace Betfanaticos.UnitTests
{
    public class ChallengeTests
    {
        [Fact]
        public void TestUpdateCurrentState()
        {
            Challenge challenge = new Challenge(
                1,
                "5 Wetten",
                "Platziere 5 Wetten",
                EnumChallangeType.PlacePrediction,
                5,
                100
            );

            challenge.UpdateProgress(1);

            Assert.Equal(1, challenge.CurrentState);
        }

        [Fact]
        public void TestChallengeComplete()
        {
            Challenge challenge = new Challenge(
                1,
                "5 Wetten",
                "Platziere 5 Wetten",
                EnumChallangeType.PlacePrediction,
                5,
                100
            );

            challenge.UpdateProgress(5);

            Assert.True(challenge.IsComplete());
        }

        [Fact]
        public void TestChallengeNotComplete()
        {
            Challenge challenge = new Challenge(
                1,
                "5 Wetten",
                "Platziere 5 Wetten",
                EnumChallangeType.PlacePrediction,
                5,
                100
            );

            challenge.UpdateProgress(3);

            Assert.False(challenge.IsComplete());
        }

        [Fact]
        public void TestRewardClaimedAfterClaimReward()
        {
            Challenge challenge = new Challenge(
                1,
                "Daily Login",
                "Logge dich einmal ein",
                EnumChallangeType.DailyLogin,
                1,
                25
            );

            challenge.UpdateProgress(1);
            challenge.ClaimReward();

            Assert.True(challenge.RewardClaimed);
        }
    }
}