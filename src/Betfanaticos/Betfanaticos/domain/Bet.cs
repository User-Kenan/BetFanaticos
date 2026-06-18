using System;
using Serilog;

namespace Betfanaticos.domain
{
    public class Bet
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int MatchID { get; set; }
        public int BetAmount { get; set; }
        public string Prediction { get; set; }
        public double Odds { get; set; }
        public BetStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Bet(int userId, int matchId, int betAmount, string prediction, double odds)
        {
            UserID = userId;
            MatchID = matchId;
            BetAmount = betAmount;
            Prediction = prediction;
            Odds = odds;
            Status = BetStatus.Open;
            CreatedAt = DateTime.Now;
        }

        
    }
}