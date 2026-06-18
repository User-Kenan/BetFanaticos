using Betfanaticos.domain;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace Betfanaticos.data.Services
{
    // Der CoinStorageService speichert und lädt die Coins eines Benutzers aus einer JSON-Datei.
    public class CoinStorageService
    {
        private string GetFilePath(User user)
        {
            return $"coins_{user.UserName}.json";
        }

        public void SaveCoins(User user)
        {
            string json = JsonSerializer.Serialize(user);
            File.WriteAllText(GetFilePath(user), json);
        }

        public void LoadCoins(User user)
        {
            string path = GetFilePath(user);

            if (!File.Exists(path))
            {
                user.Coins = 1000;
                SaveCoins(user);
                return;
            }

            string json = File.ReadAllText(path);
            User savedUser = JsonSerializer.Deserialize<User>(json);

            user.Coins = savedUser.Coins;
        }
    }
}