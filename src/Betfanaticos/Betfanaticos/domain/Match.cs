using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class Match
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public string League { get; set; }
        public int AwayScore { get; set; }
        public int HomeScore { get; set; }
        public SportType Sport { get; set; }
        public string Status { get; set; }
        public double HomeOdds { get; set; }
        public double AwayOdds { get; set; }
        public double DrawOdds { get; set; }



        public Match(string hometeam, string awayteam, string league, SportType sport, DateTime matchdate)
        {
            HomeTeam = hometeam;
            AwayTeam = awayteam;
            League = league;
            Sport = sport;
            MatchDate = matchdate;
        }





    }


}
