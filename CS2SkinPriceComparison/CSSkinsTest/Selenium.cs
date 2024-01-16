using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CS2SkinPriceComparison;

public class Selenium
{
    public string GetPricesFromSkinPort(Skin item)
    {
        string skinPortUrl = DefineSkinPortUrl(item);
        int attempts = 0;
        string price = "";
        while (attempts < 5)
        {
            IWebDriver driver = new ChromeDriver();
            var options = new ChromeOptions();  
            options.AddArguments("--incognito", "--disable-extensions", "--disable-popup-blocking", "--ignore-certificate-errors", "--ignore-ssl-errors");
            driver.Url = skinPortUrl;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement webElement = wait.Until(driver =>
                    driver.FindElement(By.ClassName("ItemPreview-priceValue")));
                price = webElement.FindElement(By.ClassName("Tooltip-link")).Text;
                attempts = 3;
                driver.Dispose();
                break;

            }
            catch (WebDriverTimeoutException)
            {
                driver.Dispose();
            }

            attempts++;
        }

        if (price == "")
        {
            return "Couldn't get price";
        }
        return Regex.Match(price, @"[0-9]+(?:[.,'´][0-9]+)?").Value;
    }

    public string DefineSkinPortUrl(Skin item)
    {
        return $"https://skinport.com/market?cat={item.SubCategory}&type={item.Item}&item={SpaceToPlus(item.Name)}&sort=price&order=asc";
    }

    public string GetPricesFromSkinBaron(Skin item)
    {
        string skinBaronUrl = DefineSkinBaronUrl(item);
        int attempts = 0;
        string price = "";
        while (attempts < 3)
        {
            IWebDriver driver = new ChromeDriver();
            var options = new ChromeOptions();
            options.AddArguments("--incognito", "--disable-extensions", "--disable-popup-blocking", "--ignore-certificate-errors", "--ignore-ssl-errors");
            driver.Url = skinBaronUrl;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            try
            {
                try
                {
                    IWebElement webElement = wait.Until(driver =>
                        driver.FindElement(By.XPath(
                            "//*[@id=\"offer-container\"]/sb-products-item-card[1]/div/a/div/div[5]/div/span")));

                    price = webElement.Text;
                    attempts = 3;
                    driver.Dispose();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    driver.Dispose();
                }
                
            }
            catch (WebDriverTimeoutException)
            {
                driver.Dispose();
            }

            attempts++;
        }

        if (price == "")
        {
            return "Couldn't get price";
        }

        return Regex.Match(price, @"[0-9]+(?:[.,'´][0-9]+)?").Value;
    }

    public string DefineSkinBaronUrl(Skin item)
    {
        string skinBaronUrl = "";
        if (item.Category == "Gun Skin")
        {
            skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.SubCategory}/{item.Item.ToString().Replace(" ", "-")}/{SpaceToHyphen(item.Name)}?sort=CF";
        }
        if (item.Category == "Knife")
        {
            skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.Category}/{SpaceToHyphen(item.Item.ToString())}/{SpaceToHyphen(item.Name)}?sort=CF";
        }
        if (item.Category == "Gloves")
        {
            skinBaronUrl = $"https://skinbaron.de/en/csgo/{item.Category}/{SpaceToHyphen(item.Item.ToString())}/{SpaceToHyphen(item.Name)}?sort=CF";
        }

        return skinBaronUrl;
    }

    public string SpaceToHyphen(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }
        string result = FirstCharToUpper(input);
        if (result.Contains(" "))
        {
            string[] splitted = result.Split(" ");
            result = string.Join("-", splitted);
        }

        return result;
    }

    public string SpaceToPlus(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }
        string result = FirstCharToUpper(input);
        if (result.Contains(" "))
        {
            string[] splitted = result.Split(" ");
            result = string.Join("+", splitted);
        }

        return result;
    }


    public string FirstCharToUpper(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }
        string result = input.Trim().ToLower();
        string[] splitted = result.Split(" ");

        for (int i = 0; i < splitted.Length; i++)
        {
            splitted[i] = splitted[i].Substring(0, 1).ToUpper() + splitted[i].Substring(1);
        }

        return string.Join(" ", splitted);
    }
}



