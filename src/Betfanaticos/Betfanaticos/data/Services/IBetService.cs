using Betfanaticos.domain;

namespace Betfanaticos.data.Services
{
    public interface IBetService
    {
        Bet PlaceBet(User user, Match match, int amount, string prediction);
    }
}