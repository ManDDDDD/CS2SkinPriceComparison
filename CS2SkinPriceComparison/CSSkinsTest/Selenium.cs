using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CS2SkinPriceComparison;

public class Selenium
{
    public string GetPricesFromSkinPort(Skin item)
    {
        string skinPortUrl = DefineSkinPortUrl(item);
        IWebDriver driver = new ChromeDriver();
        driver.Url = skinPortUrl;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[3]/div[2]/div[1]/div/div/div[1]/a/div[1]/div[3]/div[1]/div[1]/div[1]")));

        string price = webElement.Text;

        return price;
    }

    public string DefineSkinPortUrl(Skin item)
    {
        string skinPortName = item.Name.Trim().Replace(" ", "+");
        skinPortName = FirstCharToUpper(skinPortName);
        string skinPortUrl = $"https://skinport.com/market?cat={item.SubCategory}&type={item.Item}&item={skinPortName}&sort=price&order=asc";

        return skinPortUrl;
    }

    public string GetPricesFromSkinBaron(Skin item)
    {
        string skinBaronUrl = DefineSkinBaronUrl(item);
        IWebDriver driver = new ChromeDriver();
        driver.Url = skinBaronUrl;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"offer-container\"]/sb-products-item-card[1]/div/a/div/div[5]/div/span")));

        string price = webElement.Text;

        return price;
    }

    public string DefineSkinBaronUrl(Skin item)
    {
        string skinBaronName = item.Name.Trim().Replace(" ", "-").ToLower();
        skinBaronName = FirstCharToUpper(skinBaronName);
        string skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.SubCategory}/{item.Item}/{skinBaronName}?sort=CF";

        return skinBaronUrl;
    }

    public string GetPricesFromSteam(Skin item)
    {
        string steamUrl = DefineSteamUrl(item);
        IWebDriver driver = new ChromeDriver();
        driver.Url = steamUrl;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"result_0\"]/div[1]/div[2]/span[1]/span[1]")));

        string price = webElement.Text;

        return price;
    }

    public string DefineSteamUrl(Skin item)
    {
        string steamName = item.Name.Trim().Replace(" ", "+").Replace("-", "");
        string steamItem = item.Item.ToString().ToLower().Replace("-", "");
        string steamUrl = $"https://steamcommunity.com/market/search?q={steamName}&category_730_ItemSet%5B%5D=any&category_730_ProPlayer%5B%5D=any&category_730_StickerCapsule%5B%5D=any&category_730_TournamentTeam%5B%5D=any&category_730_Weapon%5B%5D=tag_weapon_{steamItem}&appid=730#p1_price_asc";

        return steamUrl;
    }

    public string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}
