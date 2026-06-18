using Betfanaticos.domain;
using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Betfanaticos.data.Services
{
    public class BetServiceREST
    {
        private readonly HttpClient client;

        // Konstruktor: Erstellt einen HttpClient und setzt die Adresse des FastAPI-Backends
        public BetServiceREST()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            Log.Information("BetServiceREST wurde initialisiert");
        }

        // Speichert eine neue Wette im Backend
        // Zuerst wird ein Bet angelegt und anschließend ein BetItem mit allen Wettinformationen gespeichert
        public async Task SaveBet(User user, Match match, int amount, string prediction, double odds)
        {
            Log.Information("Neue Wette wird gespeichert: UserId={UserId}, MatchId={MatchId}, Amount={Amount}, Prediction={Prediction}, Odds={Odds}", user.Id, match.Id, amount, prediction, odds);
            var betRequest = new BetCreateRequest
            {
                status = "Open",
                user_id = user.Id
            };


            var betResponse = await client.PostAsJsonAsync("bet/", betRequest);
            var betContent = await betResponse.Content.ReadAsStringAsync();

            if (!betResponse.IsSuccessStatusCode)
            {
                Log.Error("Fehler beim Speichern der Wette");
                throw new Exception(betContent);

            }

            var createdBet = JsonSerializer.Deserialize<BetCreateResponse>(
                betContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            var betItemRequest = new BetitemCreateRequest
            {
                score_team_a = match.HomeScore,
                score_team_b = match.AwayScore,
                bet_money = amount,
                status = "Open",
                bet_type = prediction,
                prediction = prediction,
                odds = odds,
                home_team = match.HomeTeam,
                away_team = match.AwayTeam,
                bet_id = createdBet.bet_id,
                match_id = match.Id
            };

            var betItemResponse = await client.PostAsJsonAsync("betitem/", betItemRequest);
            var betItemContent = await betItemResponse.Content.ReadAsStringAsync();

            if (!betItemResponse.IsSuccessStatusCode)
                throw new Exception(betItemContent);
        }

        // Lädt alle offenen Wetten eines bestimmten Benutzers aus dem Backend
        public async Task<List<BetitemResponse>> GetOpenBetsByUserId(int userId)
        {
            var response = await client.GetAsync($"betitem/open/{userId}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<List<BetitemResponse>>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? new List<BetitemResponse>();
        }

        // Aktualisiert eine vorhandene Wette (Status => WON/LOST)
        public async Task UpdateBetItem(BetitemResponse betitem)
        {
            var request = new BetitemCreateRequest
            {
                score_team_a = betitem.score_team_a,
                score_team_b = betitem.score_team_b,
                bet_money = betitem.bet_money,
                status = betitem.status,
                bet_type = betitem.bet_type,
                prediction = betitem.prediction,
                odds = betitem.odds,
                home_team = betitem.home_team,
                away_team = betitem.away_team,
                bet_id = betitem.bet_id,
                match_id = betitem.match_id
            };

            var response = await client.PutAsJsonAsync($"betitem/{betitem.bet_item_id}", request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);
        }

        public async Task<int> EvaluateOpenBets(User user, List<Match> currentMatches)
        {
            var openBets = await GetOpenBetsByUserId(user.Id);

            int totalWonCoins = 0;

            foreach (var bet in openBets)
            {
                Match? match = currentMatches.FirstOrDefault(m => m.Id == bet.match_id);

                if (match == null)
                    continue;

                if (match.Status != "Finished")
                    continue;

                string winner;

                if (match.HomeScore > match.AwayScore)
                {
                    winner = match.HomeTeam;
                }
                else if (match.AwayScore > match.HomeScore)
                {
                    winner = match.AwayTeam;
                }
                else
                {
                    winner = "Draw";
                }

                if (bet.prediction == winner)
                {
                    int wonCoins = (int)(bet.bet_money * bet.odds);
                    user.AddCoins(wonCoins);
                    totalWonCoins += wonCoins;
                    bet.status = "Won";
                }
                else
                {
                    bet.status = "Lost";
                }

                bet.score_team_a = match.HomeScore;
                bet.score_team_b = match.AwayScore;

                await UpdateBetItem(bet);
            }

            return totalWonCoins;
        }
    }

    public class BetCreateRequest
    {
        public string status { get; set; }
        public int user_id { get; set; }
    }

    public class BetCreateResponse
    {
        public int bet_id { get; set; }
        public string status { get; set; }
        public int user_id { get; set; }
    }

    public class BetitemCreateRequest
    {
        public int score_team_a { get; set; }
        public int score_team_b { get; set; }
        public double bet_money { get; set; }
        public string status { get; set; }
        public string bet_type { get; set; }
        public string prediction { get; set; }
        public double odds { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }
        public int bet_id { get; set; }
        public int match_id { get; set; }
    }

    public class BetitemResponse
    {
        public int bet_item_id { get; set; }
        public int score_team_a { get; set; }
        public int score_team_b { get; set; }
        public double bet_money { get; set; }
        public string status { get; set; }
        public string bet_type { get; set; }
        public string prediction { get; set; }
        public double odds { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }
        public int bet_id { get; set; }
        public int match_id { get; set; }
    }
}