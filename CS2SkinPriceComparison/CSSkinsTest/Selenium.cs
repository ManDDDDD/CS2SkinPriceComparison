using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace CS2SkinPriceComparison;

public class Selenium
{
    string skinName = Console.ReadLine();
    string skinBaronName = skinName.Replace(" ", "-");

    string skinPortUrl = $"https://skinport.com/market?cat={mySkin.WeaponCategory}&type={mySkin.SpecificWeapon}&item={skinPortName}";
    string skinBaronUrl = $"https://skinbaron.de/en/csgo/{mySkin.WeaponCategory}/{mySkin.SpecificWeapon}/{skinBaronName}";
    string steamUrl = $"https://steamcommunity.com/market/search?q={skinName}&category_730_ItemSet%5B%5D=any&category_730_ProPlayer%5B%5D=any&category_730_StickerCapsule%5B%5D=any&category_730_TournamentTeam%5B%5D=any&category_730_Weapon%5B%5D=tag_weapon_{mySkin.SpecificWeapon.ToString().ToLower()}&appid=730#p1_price_asc";

    public string GetPricesFromSkinPort(Skin item)
    {
        DefineSkinPortUrl(item);
        IWebDriver driver = new ChromeDriver();
        driver.Url = itemLink;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[3]/div[2]/div[1]/div/div/div[1]/a/div[1]/div[4]/div[1]/div[1]/div[1]")));

        string price = webElement.Text;

        return price;
    }

    public string DefineSkinPortUrl(Skin item)
    {
        string skinPortName = skinName.Replace(" ", "+");
        string skinPortUrl = $"https://skinport.com/market?cat={mySkin.WeaponCategory}&type={mySkin.SpecificWeapon}&item={skinPortName}";

        return skinPortUrl;
    }

    public string GetPricesFromSkinBaron(string itemLink)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Url = itemLink;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"offer-container\"]/sb-products-item-card[1]/div/a/div/div[5]/div/span")));

        string price = webElement.Text;

        return price;
    }

    public string GetPricesSteam(string itemLink)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Url = itemLink;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"result_0\"]/div[1]/div[2]/span[1]/span[1]")));

        string price = webElement.Text;

        return price;
    }
}