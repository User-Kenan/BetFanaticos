using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betfanaticos.domain;

namespace Betfanaticos.UnitTests
{
    
    public class MatchTests
    {
        [Fact]
        public void TestHomeTeam()
        {
            Match match = new Match("Germany", "France", "World Cup", SportType.Football, DateTime.Now);

            Assert.Equal("Germany", match.HomeTeam);
        }

        [Fact]
        public void TestAwayTeam()
        {
            Match match = new Match("Germany", "France", "World Cup", SportType.Football, DateTime.Now);

            Assert.Equal("France", match.AwayTeam);
        }

        [Fact]
        public void TestLeague()
        {
            Match match = new Match("Germany", "France", "World Cup", SportType.Football, DateTime.Now);

            Assert.Equal("World Cup", match.League);
        }

        [Fact]
        public void TestSport()
        {
            Match match = new Match("Germany", "France", "World Cup", SportType.Football, DateTime.Now);

            Assert.Equal(SportType.Football, match.Sport);
        }

        [Fact]
        public void TestHomeScore()
        {
            Match match = new Match("Germany", "France", "World Cup", SportType.Football, DateTime.Now);

            match.HomeScore = 2;

            Assert.Equal(2, match.HomeScore);
        }

        [Fact]
        public void TestAwayScore()
        {
            Match match = new Match("Germany", "France", "World Cup", SportType.Football, DateTime.Now);

            match.AwayScore = 1;

            Assert.Equal(1, match.AwayScore);
        }
    }
}
