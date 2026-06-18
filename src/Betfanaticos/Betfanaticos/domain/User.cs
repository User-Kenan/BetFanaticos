using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswortHash { get; set; }
        public double Coins { get; set; }
        public string FavouriteTeam { get; set; }


        public User(string username, string passwordHash, string favouriteTeam, double coins)
        {
            UserName = username;
            PasswortHash = passwordHash;
            FavouriteTeam = favouriteTeam;
            Coins = coins;
        }

        public User()
        {

        }


        public double AddCoins(double coins)
        {
            Coins += coins;
            return Coins;
        }

        public bool RemoveCoins(double coins)
        {
            if (coins <= 0)
            {
                return false;
            }
            if (Coins < coins)
            {
                return false;
            }

            Coins -= coins;
            return true;
        }



    }

}
