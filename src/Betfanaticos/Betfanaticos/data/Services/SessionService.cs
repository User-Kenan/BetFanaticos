using Betfanaticos.data.models;
using Betfanaticos.domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Betfanaticos.data.Services
{
    public static class SessionService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://127.0.0.1:8000/")
        };

        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string ApiKey { get; private set; }

        public static bool IsLoggedIn => ApiKey != null;

        public static User CurrentUser { get; private set; }
        public static ChallangeManager ChallangeManager { get; private set; }

        public static WalletServiceREST WalletService { get; private set; }
        public static BetServiceREST BetService { get; private set; }

        public static async Task SetUserAsync(LoginResponse response)
        {
            UserId = response.user.userId;
            Username = response.user.name;
            ApiKey = response.api_key;

            CurrentUser = new User
            {
                Id = UserId,
                UserName = Username,
                Coins = 0
            };

            WalletService = new WalletServiceREST();
            BetService = new BetServiceREST(client);

            var challengeService = new ChallengeServiceREST(client);
            ChallangeManager = new ChallangeManager(challengeService);

            await ChallangeManager.LoadChallengesAsync();
            await ReloadCoinsAsync();
        }

        public static async Task ReloadCoinsAsync()
        {
            if (CurrentUser == null)
                return;

            var wallet = await WalletService.GetWalletByUserId(CurrentUser.Id);
            CurrentUser.Coins = wallet.coins;
        }

        public static void Logout()
        {
            UserId = 0;
            Username = null;
            ApiKey = null;

            CurrentUser = null;
            ChallangeManager = null;
            WalletService = null;
            BetService = null;
        }
    }
}