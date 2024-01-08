using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CS2SkinPriceComparison;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose a weapon type:");
        foreach (WeaponCategory weaponCategory in Enum.GetValues(typeof(WeaponCategory)))
        {
            Console.WriteLine($"{(int)weaponCategory}. {weaponCategory}");
        }

        string weaponCategoryInput = Console.ReadLine();
        if (Enum.TryParse(weaponCategoryInput, out WeaponCategory selectedWeaponCategory))
        {
            Skin mySkin = new Skin { WeaponCategory = selectedWeaponCategory };

            if (selectedWeaponCategory == WeaponCategory.Rifle)
            {
                Console.WriteLine("Choose a rifle type:");
                foreach (RifleType rifleType in Enum.GetValues(typeof(RifleType)))
                {
                    Console.WriteLine($"{(int)rifleType}. {rifleType}");
                }

                string rifleTypeInput = Console.ReadLine();
                if (Enum.TryParse(rifleTypeInput, out RifleType selectedRifleType))
                {
                    mySkin.SpecificWeapon = selectedRifleType;
                }
                else
                {
                    Console.WriteLine("Invalid rifle selection.");
                    return;
                }
            }

            if (selectedWeaponCategory == WeaponCategory.Pistol)
            {
                Console.WriteLine("Choose a pistol type:");
                foreach (PistolType pistolType in Enum.GetValues(typeof(PistolType)))
                {
                    Console.WriteLine($"{(int)pistolType}. {pistolType}");
                }

                string pistolTypeInput = Console.ReadLine();
                if (Enum.TryParse(pistolTypeInput, out PistolType selectedPistolType))
                {
                    mySkin.SpecificWeapon = selectedPistolType;
                }
                else
                {
                    Console.WriteLine("Invalid pistol selection.");
                    return;
                }
            }

            Console.WriteLine("Enter a skin name: ");
            string skinName = Console.ReadLine();
            string skinBaronName = skinName.Replace(" ", "-");
            string skinPortName = skinName.Replace(" ", "+");

            // Hier kannst du mySkin weiter verarbeiten
            Console.WriteLine($"You selected : {mySkin.WeaponCategory}");
            Console.WriteLine($"{mySkin.WeaponCategory} type: {mySkin.SpecificWeapon}");
            Console.WriteLine($"{mySkin.SpecificWeapon} skin: {skinName}");
            
            Console.WriteLine("Getting Data...");

            string skinPortUrl = $"https://skinport.com/market?cat={mySkin.WeaponCategory}&type={mySkin.SpecificWeapon}&item={skinPortName}";
            string skinBaronUrl = $"https://skinbaron.de/en/csgo/{mySkin.WeaponCategory}/{mySkin.SpecificWeapon}/{skinBaronName}";

            string priceSkinPort = GetPricesFromSkinPort(skinPortUrl);
            string priceSkinBaron = GetPricesFromSkinBaron(skinBaronUrl);

            Console.WriteLine($"The Price on Skinport is: {priceSkinPort}");
            Console.WriteLine($"The Price on SkinBaron is: {priceSkinBaron}");

        }
        else
        {
            Console.WriteLine("Invalid weapon type selection.");
        }


    }
    public static string GetPricesFromSkinPort(string itemLink)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Url = itemLink;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[3]/div[2]/div[1]/div/div/div[1]/a/div[1]/div[4]/div[1]/div[1]/div[1]")));

        string price = webElement.Text;

        return price;
    }

    public static string GetPricesFromSkinBaron(string itemLink)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Url = itemLink;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement webElement = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"offer-container\"]/sb-products-item-card[1]/div/a/div/div[5]/div/span")));

        string price = webElement.Text;

        return price;
    }
}