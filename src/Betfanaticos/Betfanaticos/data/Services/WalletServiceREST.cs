using Serilog;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Betfanaticos.data.Services
{
    // Der WalletServiceREST lädt und aktualisiert die Coins eines Benutzers über das FastAPI-Backend.
    public class WalletServiceREST
    {
        private readonly HttpClient client;

        public WalletServiceREST()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
        }

        public async Task<WalletResponse> GetWalletByUserId(int userId)
        {
            Log.Information("Wallet von Benutzer {UserId} wird geladen", userId);
            var response = await client.GetAsync($"wallet/user/{userId}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<WalletResponse>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<WalletResponse> UpdateWalletByUserId(int userId, double coins)
        {
            var request = new WalletCreate
            {
                user_id = userId,
                coins = coins
            };

            var response = await client.PutAsJsonAsync($"wallet/user/{userId}", request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<WalletResponse>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }

    public class WalletCreate
    {
        public int user_id { get; set; }
        public double coins { get; set; }
    }

    public class WalletResponse
    {
        public int wallet_id { get; set; }
        public int user_id { get; set; }
        public double coins { get; set; }
    }
}