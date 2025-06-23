using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_testing
{
    using Xunit;
    using Services;

    public class UserServicesPasswordTests
    {
        // Helper to create a UserServies (with nulls for unused dependencies)
        private UserServies CreateService() =>
            new UserServies(null, null, null);

        [Theory]
        [InlineData(null, -1)]                 // Null input returns -1
        [InlineData("", -1)]                   // Empty input returns -1
        [InlineData("123456", 0)]              // Very weak password
        [InlineData("password", 0)]            // Common weak password
        [InlineData("PasswoPP89rd123!", 3)]        // Strong password
        [InlineData("Th1s1s@StrongP@ss", 4)]   // Very strong password
        [InlineData("weak", 0)]                // Short/weak password
        public void PowerOfPassword_ReturnsExpectedScore(string password, int expectedMinScore)
        {
            // Arrange
            var service = CreateService();

            // Act
            int score = service.powerOfPassword(password);

            // Assert
            // Zxcvbn may give scores from 0 to 4, so we check for expected minimum
            Assert.True(score >= expectedMinScore, $"Score for '{password}' was {score}, expected at least {expectedMinScore}");
        }
    }
}
