using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string PasswortHash { get; set; }
        public int Coins { get; set; }
        public string FavouriteTeam { get; set; }


        public User(string username, string passwordHash, string favouriteTeam, int coins)
        {
            UserName = username;
            PasswortHash = passwordHash;
            FavouriteTeam = favouriteTeam;
            Coins = coins;
        }


        public int AddCoins(int coins)
        {
            Coins += coins;
            return Coins;
        }

        public int RemoveCoins(int coins)
        {
            Coins -= coins;
            return Coins;
        }



    }

}
