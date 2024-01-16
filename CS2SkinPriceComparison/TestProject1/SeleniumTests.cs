using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS2SkinPriceComparison;

namespace CS2SkinPriceComparison.Tests
{
    [TestClass]
    public class SeleniumTests
    {
        [TestMethod]
        [DataRow("Fuel Injector", "Gun Skin", "Rifle", "AK-47")]
        [DataRow("Tiger Tooth", "Knife", "", "Karambit")]
        [DataRow("Omega", "Gloves", "", "Sport Gloves")]
        [DataRow("Autotronic", "Knife", "", "Gut Knife")]
        public void TestGetPricesFromSkinPort(string name, string category, string subCategory, string item)
        {
            // Arrange
            Selenium selenium = new Selenium();
            Skin skin = new Skin
            {
                Name = name,
                Category = category,
                SubCategory = subCategory,
                Item = item
            };

            // Act
            string price = selenium.GetPricesFromSkinPort(skin);

            // Assert
            Assert.IsNotNull(price, "Price should not be null");
        }
        
        [TestMethod]
        [DataRow("Invalid Skin Name", "Gun Skin", "Rifle", "AK-47")]
        public void GetPricesFromSkinportWithInvalidSkinShouldReturnErrorMessage(string name, string category, string subCategory, string item)
        {
            // Arrange
            Selenium selenium = new Selenium();
            Skin skin = new Skin
            {
                Name = name,
                Category = category,
                SubCategory = subCategory,
                Item = item
            };

            // Act
            string price = selenium.GetPricesFromSkinPort(skin);

            // Assert
            Assert.AreEqual("Couldn't get price", price, "Price should be 'Couldn't get price'");
        }

        [TestMethod]
        [DataRow("Fuel Injector", "Gun Skin", "Rifle", "AK-47")]
        [DataRow("Tiger Tooth", "Knife", "", "Karambit")]
        [DataRow("Omega", "Gloves", "", "Sport Gloves")]
        [DataRow("Autotronic", "Knife", "", "Gut Knife")]
        public void TestDefineSkinPortUrl(string name, string category, string subCategory, string item)
        {
            // Arrange
            Selenium selenium = new Selenium();
            Skin skin = new Skin
            {
                Name = name,
                Category = category,
                SubCategory = subCategory,
                Item = item
            };

            // Act
            string url = selenium.DefineSkinPortUrl(skin);

            // Assert
            Assert.IsNotNull(url, "URL should not be null");
        }

        [TestMethod]
        [DataRow("Fuel Injector", "Gun Skin", "Rifle", "AK-47")]
        [DataRow("Tiger Tooth", "Knife", "", "Karambit")]
        [DataRow("Omega", "Gloves", "", "Sport Gloves")]
        [DataRow("Autotronic", "Knife", "", "Gut Knife")]
        public void TestGetPricesFromSkinbaron(string name, string category, string subCategory, string item)
        {
            // Arrange
            Selenium selenium = new Selenium();
            Skin skin = new Skin
            {
                Name = name,
                Category = category,
                SubCategory = subCategory,
                Item = item
            };

            // Act
            string price = selenium.GetPricesFromSkinBaron(skin);

            // Assert
            Assert.IsNotNull(price, "Price should not be null");
        }
        
        [TestMethod]
        [DataRow("Invalid Skin Name", "Gun Skin", "Rifle", "AK-47")]
        public void GetPricesFromSkinbaronWithInvalidSkinShouldReturnErrorMessage(string name, string category, string subCategory, string item)
        {
            // Arrange
            Selenium selenium = new Selenium();
            Skin skin = new Skin
            {
                Name = name,
                Category = category,
                SubCategory = subCategory,
                Item = item
            };

            // Act
            string price = selenium.GetPricesFromSkinBaron(skin);

            // Assert
            Assert.AreEqual("Couldn't get price", price, "Price should be 'Couldn't get price'");
        }

        [TestMethod]
        [DataRow("Fuel Injector", "Gun Skin", "Rifle", "AK-47")]
        [DataRow("Tiger Tooth", "Knife", "", "Karambit")]
        [DataRow("Omega", "Gloves", "", "Sport Gloves")]
        [DataRow("Autotronic", "Knife", "", "Gut Knife")]
        public void TestDefineSkinbaronUrl(string name, string category, string subCategory, string item)
        {
            // Arrange
            Selenium selenium = new Selenium();
            Skin skin = new Skin
            {
                Name = name,
                Category = category,
                SubCategory = subCategory,
                Item = item
            };

            // Act
            string url = selenium.DefineSkinBaronUrl(skin);

            // Assert
            Assert.IsNotNull(url, "URL should not be null");
        }

        [TestMethod]
        [DataRow("test", "Test")]
        [DataRow("THis is a SentEnce", "This-Is-A-Sentence")]
        [DataRow(" test SenTence ", "Test-Sentence")]
        [DataRow("", "")]
        [DataRow(" ", "")]
        public void SpaceToHyphen_ShouldReplaceSpacesWithHyphens(string input, string expectedResult)
        {
            // Arrange
            Selenium selenium = new Selenium();

            // Act
            string result = selenium.SpaceToHyphen(input);

            // Assert
            Assert.AreEqual(expectedResult, result, "Result should match");
        }

        [TestMethod]
        [DataRow("test", "Test")]
        [DataRow("THis is a SentEnce", "This+Is+A+Sentence")]
        [DataRow(" test SenTence ", "Test+Sentence")]
        [DataRow("", "")]
        [DataRow(" ", "")]
        public void SpaceToPlus_ShouldReplaceSpacesWithPluses(string input, string expectedResult)
        {
            // Arrange
            Selenium selenium = new Selenium();

            // Act
            string result = selenium.SpaceToPlus(input);

            // Assert
            Assert.AreEqual(expectedResult, result, "Result should match");
        }

        [TestMethod]
        [DataRow("test", "Test")]
        [DataRow("Test", "Test")]
        [DataRow(" asiimov", "Asiimov")]
        [DataRow(" thiS iS a TeSt sTring ", "This Is A Test String")]
        [DataRow("", "")]
        [DataRow(" ", "")]
        public void FirstCharToUpper_ShouldCapitalizeFirstLetter(string input, string expectedResult)
        {
            // Arrange
            Selenium selenium = new Selenium();

            // Act
            string result = selenium.FirstCharToUpper(input);

            // Assert
            Assert.AreEqual(expectedResult, result, "Result should match");
        }
    }
}
