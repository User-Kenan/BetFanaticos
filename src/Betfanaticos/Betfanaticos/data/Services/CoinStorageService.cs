using System.IO;
using System.Text.Json;
using Betfanaticos.domain;

namespace Betfanaticos.data.Services
{
    // Coins speicher und Laden 
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