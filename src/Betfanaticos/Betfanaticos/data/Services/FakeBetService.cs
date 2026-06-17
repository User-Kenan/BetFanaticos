using Betfanaticos.domain;

namespace Betfanaticos.data.Services
{
    public class FakeBetService : IBetService
    {
        public Bet PlaceBet(User user, Match match, int amount, string prediction, double odds)
        {
            if (amount <= 0)
                throw new Exception("Betrag muss größer als 0 sein.");

            if (user.Coins < amount)
                throw new Exception("Du hast nicht genug Coins.");

            user.RemoveCoins(amount);

            Bet bet = new Bet(
                user.Id,
                match.Id,
                amount,
                prediction,
                odds
            );

            return bet;
        }
    }
}