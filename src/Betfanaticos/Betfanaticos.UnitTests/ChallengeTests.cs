using Betfanaticos.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Betfanaticos.UnitTests
{
    public class ChallengeTests
    {
        [Fact]
        public void TestUpdateCurrentState()
        {
            Challenge challenge = new Challenge("5 Wetten", "Platziere 5 Wetten", EnumChallangeType.BetOnGame, 5);

            challenge.UpdateCurrentState(1);

            Assert.Equal(1, challenge.CurrentState);
        }

        [Fact]
        public void TestChallengeComplete()
        {
            Challenge challenge = new Challenge("5 Wetten", "Platziere 5 Wetten", EnumChallangeType.BetOnGame, 5);

            challenge.UpdateCurrentState(5);

            Assert.True(challenge.IsComplete());
        }

        [Fact]
        public void TestChallengeNotComplete()
        {
            Challenge challenge = new Challenge("5 Wetten", "Platziere 5 Wetten", EnumChallangeType.BetOnGame, 5);

            challenge.UpdateCurrentState(3);

            Assert.False(challenge.IsComplete());
        }
    }
}
