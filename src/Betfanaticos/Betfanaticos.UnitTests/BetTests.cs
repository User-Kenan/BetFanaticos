using Betfanaticos.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.UnitTests
{
    public class BetTests
    {
        [Fact]
        public void TestUserID()
        {
            Bet bet = new Bet(1, 10, 100, "Germany", 2.0);

            Assert.Equal(1, bet.UserID);
        }

        [Fact]
        public void TestMatchID()
        {
            Bet bet = new Bet(1, 10, 100, "Germany", 2.0);

            Assert.Equal(10, bet.MatchID);
        }

        [Fact]
        public void TestBetAmount()
        {
            Bet bet = new Bet(1, 10, 100, "Germany", 2.0);

            Assert.Equal(100, bet.BetAmount);
        }

        [Fact]
        public void TestPrediction()
        {
            Bet bet = new Bet(1, 10, 100, "Germany", 2.0);

            Assert.Equal("Germany", bet.Prediction);
        }

        [Fact]
        public void TestStatus()
        {
            Bet bet = new Bet(1, 10, 100, "Germany", 2.0);

            Assert.Equal(BetStatus.Open, bet.Status);
        }

        
    }
}