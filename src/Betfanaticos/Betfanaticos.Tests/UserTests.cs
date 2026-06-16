using Xunit;
using Betfanaticos.domain;

namespace Betfanaticos.Tests
{
    public class UserTests
    {
        [Fact]
        public void AddCoins_ShouldIncreaseCoins()
        {
            // Arrange
            User user = new User("Test", "123", "Germany", 100);

            // Act
            user.AddCoins(50);

            // Assert
            Assert.Equal(150, user.Coins);
        }

        [Fact]
        public void RemoveCoins_ShouldDecreaseCoins()
        {
            // Arrange
            User user = new User("Test", "123", "Germany", 100);

            // Act
            user.RemoveCoins(30);

            // Assert
            Assert.Equal(70, user.Coins);
        }

        [Fact]
        public void AddAndRemoveCoins_ShouldReturnOriginalValue()
        {
            // Arrange
            User user = new User("Test", "123", "Germany", 100);

            // Act
            user.AddCoins(50);
            user.RemoveCoins(50);

            // Assert
            Assert.Equal(100, user.Coins);
        }
    }
}