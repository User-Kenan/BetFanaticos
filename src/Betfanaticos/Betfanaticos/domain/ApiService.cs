using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

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
    }
}