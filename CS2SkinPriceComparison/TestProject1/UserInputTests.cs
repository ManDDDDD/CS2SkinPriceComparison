using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS2SkinPriceComparison;
using Newtonsoft.Json.Linq;

namespace CS2SkinPriceComparison.Tests
{
    [TestClass]
    public class UserInputTests
    {

        [TestMethod]
        public void TestGetCHFPriceFromEUR()
        {
            // Arrange
            var userInput = new UserInput();

            // Act
            var result = userInput.GetCHFPriceFromEUR(100, "EUR").Result;

            // Assert
            Assert.IsNotNull(result, "Result should not be null");
            Assert.IsTrue(result > 0, "Result should be greater than 0");
            // Add more assertions based on the expected behavior of GetCHFPriceFromEUR
        }
    }
}
