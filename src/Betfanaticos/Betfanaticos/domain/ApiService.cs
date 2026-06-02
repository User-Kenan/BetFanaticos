using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class ApiService
    {
        // HTTP-Anfragen an eine API zu senden
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();

            // API Schlüssel 
            _client.DefaultRequestHeaders.Add("X-Auth-Token", "cc9941e4e76441ad860b0b38da3fb426");
        }

        // liefert eine Liste von Match Objekten zurück 
        public async Task<List<Match>> GetFootballMatchesAsync()
        {
            // Ladet JSON Inhalte herunter und speichert ihnn als string  
            string json = await _client.GetStringAsync("https://api.football-data.org/v4/competitions/PL/matches");

            // JSON in Obejkt umwandel
            FootballApiResponse? response =
                JsonSerializer.Deserialize<FootballApiResponse>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            List<Match> matches = new List<Match>();

            // nimmt die Daten aus der API und erstellt daraus eigenen Match-Objekte
            foreach (ApiMatch apiMatch in response.Matches)
            {
                Match match = new Match(
                    apiMatch.HomeTeam.Name,
                    apiMatch.AwayTeam.Name,
                    "Premier League",
                    SportType.Football,
                    apiMatch.UtcDate    
                );

                match.HomeScore = apiMatch.Score.FullTime.Home ?? 0;
                match.AwayScore = apiMatch.Score.FullTime.Away ?? 0;

                matches.Add(match);
            }
            // Sortiert spiele nach Datum 
            // Die ersten 30 Spiele werden genommen
            // Wird in Liste umgewandelt 
            return matches.OrderBy(m => m.MatchDate).Take(30).ToList();
        }
    }
}