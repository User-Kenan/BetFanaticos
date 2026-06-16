using Betfanaticos.domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos
{
    public class Challenge
    {
        private Bet bet;
        public int id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public EnumChallangeType ChallengeType;
        public int RequiredAmount { get; private set; }
        public int CurrentState { get; private set; }

        public Challenge(string title,string description,EnumChallangeType challengeType,int requiredAmount)
        {
            Title = title;
            Description = description;
            ChallengeType = challengeType;
            RequiredAmount = requiredAmount;
            CurrentState = 0;


        }

        public void UpdateCurrentState(int amount)
        {
            Log.Information("Challenge Fortschritt erhöht. Challenge");
            CurrentState = CurrentState + amount;
        }

        public bool IsComplete()
        {         

            if (RequiredAmount == CurrentState)
            {
                Log.Information("Challenge abgeschlossen");
                return true;
            }

            return false;
        }
    }
}
