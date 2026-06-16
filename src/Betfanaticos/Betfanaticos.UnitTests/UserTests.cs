namespace Betfanaticos.UnitTests;

using Betfanaticos.domain;
using Xunit;


public class UserTests
{
    [Fact]
    public void AddCoins_ShouldIncreaseCoins()
    {
        User user = new User("Test", "123", "Germany", 100);

        user.AddCoins(50);

        Assert.Equal(150, user.Coins);
    }

    [Fact]
    public void RemoveCoins_ShouldRemoveCoins()
    {
        User user = new User("Test", "123", "Germany", 100);

        bool result = user.RemoveCoins(30);

        Assert.True(result);
        Assert.Equal(70, user.Coins);
    }

    [Fact]
    public void RemoveCoins_ShouldReturnFalse_WhenAmountIsZero()
    {
        User user = new User("Test", "123", "Germany", 100);

        bool result = user.RemoveCoins(0);

        Assert.False(result);
        Assert.Equal(100, user.Coins);
    }

    [Fact]
    public void RemoveCoins_ShouldReturnFalse_WhenNotEnoughCoins()
    {
        User user = new User("Test", "123", "Germany", 100);

        bool result = user.RemoveCoins(200);

        Assert.False(result);
        Assert.Equal(100, user.Coins);
    }


}