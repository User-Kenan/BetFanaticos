using Betfanaticos.domain;

namespace Betfanaticos.data.Services
{
    public interface IBetService
    {
        Task<Bet> PlaceBet(User user, Match match, int amount, string prediction, double odds);
    }
}