using Betfanaticos.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.data.Services
{
    public class BetServiceREST : IBetService
    {

        private readonly HttpClient client;

        public BetServiceREST(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Bet> PlaceBet(
            User user,
            Match match,
            int amount,
            string prediction,
            double odds)
        {
            var request = new
            {
                user_id = user.Id,
                match_id = match.Id,
                amount = amount,
                prediction = prediction,
                odds = odds
            };

            var response = await client.PostAsJsonAsync("bet/create", request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            return new Bet(user.Id, match.Id, amount, prediction, odds);
        }
    }
}
