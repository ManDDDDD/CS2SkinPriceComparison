using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CS2SkinPriceComparison;

public class Selenium
{
    public string GetPricesFromSkinPort(Skin item)
    {
        string skinPortUrl = DefineSkinPortUrl(item);
        int attempts = 0;
        string price = "";
        while (attempts < 3)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = skinPortUrl;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement webElement = wait.Until(driver =>
                    driver.FindElement(By.ClassName("ItemPreview-priceValue")));
                price = webElement.FindElement(By.ClassName("Tooltip-link")).Text;
                attempts = 3;
                driver.Close();
                break;

            }
            catch (WebDriverTimeoutException e)
            {
                driver.Close();
            }

            attempts++;
        }

        if (price == "")
        {
            return "Couldn't get price";
        }
        return Regex.Match(price, @"[0-9]+(?:[.,'´][0-9]+)?").Value.Replace(",", "");
    }

    public string DefineSkinPortUrl(Skin item)
    {
        return $"https://skinport.com/market?cat={item.SubCategory}&type={item.Item}&item={spaceToPlus(item.Name)}&sort=price&order=asc";
    }

    public string GetPricesFromSkinBaron(Skin item)
    {
        string skinBaronUrl = DefineSkinBaronUrl(item);
        int attempts = 0;
        string price = "";
        while (attempts < 3)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = skinBaronUrl;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            try
            {
                IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"offer-container\"]/sb-products-item-card[1]/div/a/div/div[5]/div/span")));

                price = webElement.Text;
                attempts = 3;
                driver.Close();
                break;
            }
            catch (WebDriverTimeoutException e)
            {
                driver.Close();
            }

            attempts++;
        }

        if (price == "")
        {
            return "Couldn't get price";
        }

        return Regex.Match(price, @"[0-9]+(?:[.,'´][0-9]+)?").Value.Replace(",", "");
    }

    public string DefineSkinBaronUrl(Skin item)
    {
        string skinBaronName = item.Name.Trim().ToLower();
        if (item.Name.Contains(" "))
        {
            string[] splitted = item.Name.Split(" ");
            FirstCharToUpper(splitted[1]);
            skinBaronName = string.Join("-", splitted);
        }

        skinBaronName = FirstCharToUpper(skinBaronName);
        string skinBaronUrl = "";
        if (item.Category == "Gun Skin")
        {
            skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.SubCategory}/{spaceToHyphen(item.Item.ToString())}/{skinBaronName}?sort=CF";
        }
        if (item.Category == "Knife")
        {
            skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.Category}/{spaceToHyphen(item.Item.ToString())}/{skinBaronName}?sort=CF";
        }
        if (item.Category == "Gloves")
        {
            skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.Category}/{spaceToHyphen(item.Item.ToString())}/{skinBaronName}?sort=CF";
        }

        return skinBaronUrl;
    }

    private string spaceToHyphen(string input)

    {
        string result = input.Trim();
        if (result.Contains(" "))
        {
            string[] splitted = result.Split(" ");
            FirstCharToUpper(splitted[1]);
            result = string.Join("-", splitted);
        }

        return result;
    }
    private string spaceToPlus(string input)

    {
        string result = input.Trim();
        if (result.Contains(" "))
        {
            string[] splitted = result.Split(" ");
            FirstCharToUpper(splitted[1]);
            result = string.Join("+", splitted);
        }

        return result;
    }

    public string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}



