using Betfanaticos.data.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class ChallangeManager
    {
        private readonly ChallengeServiceREST challengeService;

        public List<Challenge> Challenges { get; } = new();

        public ChallangeManager(ChallengeServiceREST challengeService)
        {
            this.challengeService = challengeService;
        }

        public async Task LoadChallengesAsync()
        {
            Challenges.Clear();

            var dbChallenges = await challengeService.GetUserChallengesAsync(
                SessionService.CurrentUser.Id
            );

            foreach (var c in dbChallenges)
            {
                Challenges.Add(new Challenge(
                    c.Id,
                    c.Type,
                    c.Description,
                    Enum.Parse<EnumChallangeType>(c.Type),
                    c.RequiredAmount,
                    c.Reward,
                    c.CurrentState,
                    c.RewardClaimed
                ));
            }
        }

        public async Task UpdateAsync(EnumChallangeType type, int amount)
        {
            foreach (var c in Challenges)
            {
                if (c.ChallengeType == type)
                {
                    var updatedChallenge = await challengeService.UpdateChallengeAsync(
                        SessionService.CurrentUser.Id,
                        c.Id,
                        amount
                    );

                    c.SetProgressFromDatabase(
                        updatedChallenge.CurrentState,
                        updatedChallenge.RewardClaimed
                    );

                    await SessionService.ReloadCoinsAsync();

                    Log.Information("Challenge aktualisiert: {Title}", c.Title);
                    break;
                }
            }
        }
    }
}