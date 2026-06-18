using Betfanaticos.data.models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Betfanaticos.data.Services
{
    public class ChallengeServiceREST
    {
        private readonly HttpClient client;

        public ChallengeServiceREST(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<ChallengeResponse>> GetUserChallengesAsync(int userId)
        {
            var result = await client.GetFromJsonAsync<List<ChallengeResponse>>(
                $"challenges/user/{userId}"
            );

            return result ?? new List<ChallengeResponse>();
        }

        public async Task<ChallengeResponse> UpdateChallengeAsync(
            int userId,
            int challengeId,
            int amount)
        {
            var response = await client.PostAsync(
                $"challenges/update?user_id={userId}&challenge_id={challengeId}&amount={amount}",
                null
            );

            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return await response.Content.ReadFromJsonAsync<ChallengeResponse>();
        }
    }
}