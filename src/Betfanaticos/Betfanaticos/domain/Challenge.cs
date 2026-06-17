using Betfanaticos.domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class Challenge
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public EnumChallangeType ChallengeType { get; }
        public int RequiredAmount { get; }
        public int CurrentState { get; private set; }
        public int Reward { get; }
        public bool RewardClaimed { get; private set; }

        public Challenge(int id, string title, string description,
            EnumChallangeType challengeType, int requiredAmount, int reward)
        {
            Id = id;
            Title = title;
            Description = description;
            ChallengeType = challengeType;
            RequiredAmount = requiredAmount;
            Reward = reward;
            CurrentState = 0;
            RewardClaimed = false;
        }

        public void UpdateProgress(int amount)
        {
            CurrentState += amount;
            Log.Information("Challenge Fortschritt erhöht: {Id}", Id);
        }

        public bool IsComplete()
        {
            return CurrentState >= RequiredAmount;
        }


        // KI Empfehlung/erweiterung, wird gebraucht, um zu prüfen, dass bei jedem neu aufruf von Challange nicht die Belohnung gesammelt wird
        public void ClaimReward()
        {
            if (!IsComplete())
                return;

            RewardClaimed = true;
            Log.Information("Reward geclaimt für Challenge {Id}", Id);
        }
        public void Reset()
        {
            CurrentState = 0;
            RewardClaimed = false;
        }
    }
}

