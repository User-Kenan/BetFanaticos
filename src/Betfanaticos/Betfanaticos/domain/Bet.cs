using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class Bet
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int MatchID { get; set; }
        public int BetAmount { get; set; }
        public string Prediction { get; set; }
        public BetStatus Status { get; set; }

        public Bet(int userid, int matchid, int betamount, string prediction)
        {
            UserID = userid;
            MatchID = matchid;
            BetAmount = betamount;
            Prediction = prediction;
            Status = BetStatus.Open;
        }
        public void CalculateResult(string winner)
        {
            

            Log.Information("Ergebnis wird berechnet");
            if (Prediction == winner)
            {
                Log.Information("Wette gewonnen");
                Status = BetStatus.Won;
            }
            else
            {
                Log.Information("Verloren");
                Status = BetStatus.Lost;
            }
        }




    }
}
