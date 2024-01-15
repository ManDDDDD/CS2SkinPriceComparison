using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS2SkinPriceComparison;

namespace CS2SkinPriceComparison.Tests
{
    [TestClass]
    public class SeleniumTests
    {
        [TestMethod]
        public void TestGetPricesFromSkinPort()
        {
            // Arrange
            var selenium = new Selenium();
            var skin = new Skin
            {
                Name = "TestSkin",
                Category = "Gun Skin",
                SubCategory = "Rifle",
                Item = "AK-47"
            };

            // Act
            string price = selenium.GetPricesFromSkinPort(skin);

            // Assert
            Assert.IsNotNull(price, "Price should not be null");
            // Add more assertions based on the expected behavior of GetPricesFromSkinPort
        }

        [TestMethod]
        public void TestDefineSkinPortUrl()
        {
            // Arrange
            var selenium = new Selenium();
            var skin = new Skin
            {
                Name = "TestSkin",
                Category = "Gun Skin",
                SubCategory = "Rifle",
                Item = "AK-47"
            };

            // Act
            string url = selenium.DefineSkinPortUrl(skin);

            // Assert
            Assert.IsNotNull(url, "URL should not be null");
            // Add more assertions based on the expected behavior of DefineSkinPortUrl
        }

        [TestMethod]
        public void TestGetPricesFromSkinBaron()
        {
            // Arrange
            var selenium = new Selenium();
            var skin = new Skin
            {
                Name = "TestSkin",
                Category = "Gun Skin",
                SubCategory = "Rifle",
                Item = "AK-47"
            };

            // Act
            string price = selenium.GetPricesFromSkinBaron(skin);

            // Assert
            Assert.IsNotNull(price, "Price should not be null");
            // Add more assertions based on the expected behavior of GetPricesFromSkinBaron
        }

        [TestMethod]
        public void TestDefineSkinBaronUrl()
        {
            // Arrange
            var selenium = new Selenium();
            var skin = new Skin
            {
                Name = "TestSkin",
                Category = "Gun Skin",
                SubCategory = "Rifle",
                Item = "AK-47"
            };

            // Act
            string url = selenium.DefineSkinBaronUrl(skin);

            // Assert
            Assert.IsNotNull(url, "URL should not be null");
            // Add more assertions based on the expected behavior of DefineSkinBaronUrl
        }

        [TestMethod]
        public void SpaceToHyphen_ShouldReplaceSpacesWithHyphens()
        {
            // Arrange
            var selenium = new Selenium();
            string input = "Test Skin";

            // Act
            string result = selenium.SpaceToHyphen(input);

            // Assert
            Assert.AreEqual("Test-Skin", result, "Result should match");
            // Add more assertions based on the expected behavior of SpaceToHyphen
        }

        [TestMethod]
        public void SpaceToPlus_ShouldReplaceSpacesWithPluses(string input, string expectedResult)
        {
            // Arrange
            var selenium = new Selenium();

            // Act
            string result = selenium.SpaceToPlus(input);

            // Assert
            Assert.AreEqual(expectedResult, result, "Result should match");
            // Add more assertions based on the expected behavior of SpaceToPlus
        }

        [TestMethod]
        [DataRow("test", "Test")]
        [DataRow("Test", "Test")]
        [DataRow(" asiimov", "Asiimov")]
        
        public void FirstCharToUpper_ShouldCapitalizeFirstLetter(string input, string expectedResult)
        {
            // Arrange
            var selenium = new Selenium();

            // Act
            string result = selenium.FirstCharToUpper(input);

            // Assert
            Assert.AreEqual(expectedResult, result, "Result should match");
            // Add more assertions based on the expected behavior of FirstCharToUpper
        }
    }
}
