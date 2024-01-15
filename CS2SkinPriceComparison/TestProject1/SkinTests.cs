using CS2SkinPriceComparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class SkinTests
    {
        [TestMethod]
        public void TestSkinProperties()
        {
            // Arrange
            var skin = new Skin
            {
                Name = "TestSkin",
                Category = "Gun Skin",
                SubCategory = "Rifle",
                Item = "AK-47"
            };

            // Act

            // Assert
            Assert.AreEqual("TestSkin", skin.Name, "Name property should match");
            Assert.AreEqual("Gun Skin", skin.Category, "Category property should match");
            Assert.AreEqual("Rifle", skin.SubCategory, "SubCategory property should match");
            Assert.AreEqual("AK-47", skin.Item, "Item property should match");
            // Add more assertions based on the expected behavior of Skin properties
        }
    }
}
