using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace Betfanaticos.domain
{
    public class ApiService
    {
        private readonly HttpClient _client = new();


        public async Task<List<Match>> GetFootballMatchesAsync()
        {
            try
            {
                Log.Information("Football API wird geladen");

                string json = await _client.GetStringAsync("http://127.0.0.1:8000/match/football-api");

                Log.Information("Football API erfolgreich geladen");


                // Chat von hier
                // => JSON in Match-Objekte deserialisieren
                return JsonSerializer.Deserialize<List<Match>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Match>();
                // bis da

            }
            // Wenn die API nicht erreichbar ist, wird eine Fehlermeldung angezeigt und eine leere Liste zurückgegeben
            catch (Exception)
            {
                Log.Error("Fehler beim Laden der Football API");
                MessageBox.Show("Backend nicht erreichbar. Bitte Python/FastAPI starten.", 
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
                Log.Information("Basketball API wird geladen");

                string json = await _client.GetStringAsync("http://127.0.0.1:8000/match/basketball-api");

                Log.Information("Basketball API erfolgreich geladen");

                return JsonSerializer.Deserialize<List<Match>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Match>();
            }



            catch
            {
                Log.Error("Fehler beim Laden der Basketball API");
                return new List<Match>();
            }
        }



        public async Task<List<ChallengeDto>> GetSidequestsAsync()
        {
            try
            {
                Log.Information("Challenges werden geladen");
                return await _client.GetFromJsonAsync<List<ChallengeDto>>("http://127.0.0.1:8000/sidequest/") ?? new List<ChallengeDto>();
                Log.Information("Challenges erfolgreich geladen");
            }
            catch
            {
                Log.Error("Fehler beim Laden der Challenges");
                return new List<ChallengeDto>();
            }
        }





        public async Task<List<Match>> GetBaseballMatchesAsync()
        {
            try
            {
                Log.Information("Baseball API wird geladen");
                string json = await _client.GetStringAsync("http://127.0.0.1:8000/match/baseball-api");
                Log.Information("Baseball API erfolgreich geladen");

                return JsonSerializer.Deserialize<List<Match>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Match>();
            }
            catch
            {
                Log.Error(ex, "Fehler beim Laden der Baseball API");
                return new List<Match>();
            }
        }
    }
}