using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http.Json;

namespace Betfanaticos.domain
{
    public class ApiService
    {
        private readonly HttpClient _client = new();





        public async Task<List<Match>> GetFootballMatchesAsync()
        {
            try
            {
                string json = await _client.GetStringAsync(
                    "http://127.0.0.1:8000/match/football-api"
                );

                return JsonSerializer.Deserialize<List<Match>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Match>();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Backend nicht erreichbar. Bitte Python/FastAPI starten.",
                    "Verbindungsfehler",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return new List<Match>();
            }
        }






        public async Task<List<Match>> GetBasketballMatchesAsync()
        {
            try
            {
                string json = await _client.GetStringAsync(
                    "http://127.0.0.1:8000/match/basketball-api"
                );

                return JsonSerializer.Deserialize<List<Match>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Match>();
            }
            catch
            {
                return new List<Match>();
            }
        }

        public async Task<List<ChallengeDto>> GetSidequestsAsync()
        {
            try
            {
                return await _client.GetFromJsonAsync<List<ChallengeDto>>(
                    "http://127.0.0.1:8000/sidequest/"
                ) ?? new List<ChallengeDto>();
            }
            catch
            {
                return new List<ChallengeDto>();
            }
        }





        public async Task<List<Match>> GetBaseballMatchesAsync()
        {
            try
            {
                string json = await _client.GetStringAsync(
                    "http://127.0.0.1:8000/match/baseball-api"
                );

                return JsonSerializer.Deserialize<List<Match>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Match>();
            }
            catch
            {
                return new List<Match>();
            }
        }
    }
}