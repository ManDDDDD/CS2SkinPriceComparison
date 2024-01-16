namespace CS2SkinPriceComparison;
using Newtonsoft.Json.Linq;


public class UserInput
{
    // load json file using the JsonReader class
    private static JObject _jsonItems = JsonReader.LoadJson("../../../Items.json");
    private static IList<string> _keys = _jsonItems.Properties().Select(p => p.Name).ToList();
    private readonly Skin _skin = new Skin();
    public void SelectItemType()
    {
        Console.WriteLine("Select a category:");
        for (int i = 0; i < _keys.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_keys[i]}");
        }

        string selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                _skin.Category = "Gun Skin";
                SelectSubType((JObject)_jsonItems["Gun Skin"]);
                break;
            case "2":
                _skin.Category = "Knife";
                SelectSubType((JObject)_jsonItems["Knife"]);
                break;
            case "3":
                _skin.Category = "Gloves";
                SelectSubType((JObject)_jsonItems["Gloves"]);
                break;
            default:
                Console.WriteLine("Invalid selection. Please try again:");
                SelectItemType();
                break;
        }
    }

    private void SelectSubType(JObject subType)
    {
        Console.Clear();
        List<string> subTypeKey = (subType).Properties().Select(p => p.Name).ToList();
        int index = 1;
        if(_skin.SubCategory != null)
        {
            Console.WriteLine("Current Selection: " + _skin.SubCategory);
        }
        else
        {
            Console.WriteLine("Current Selection: " + _skin.Category);
        }
        Console.WriteLine("Select a Gun Type:");
        foreach (string item in subTypeKey)
        {
            Console.WriteLine($"{index}. {item}");
            index++;
        }
        string selection = Console.ReadLine();

        if (!int.TryParse(selection, out int intSelection))
        {
            Console.WriteLine("Invalid selection. Please try again:");
            SelectSubType(subType);
        }
        if (intSelection < 1 || intSelection > subTypeKey.Count)
        {
            Console.WriteLine("Invalid selection. Please try again:");
            SelectSubType(subType);
        }
        else
        {
            string selectedSubType = subTypeKey[intSelection - 1];
            if (subType[selectedSubType] is JObject)
            {
                _skin.SubCategory = selectedSubType;
                SelectSubType((JObject)subType[selectedSubType]);
            }
            else if (subType[selectedSubType] is JValue)
            {
                _skin.Item = subType[selectedSubType];
                SelectSkin((string)subType[selectedSubType]);
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again:");
                SelectSubType(subType);
            }
        }
    }

    private void SelectSkin(string item)
    {
        Console.Clear();
        Console.WriteLine("Current Selection: " + _skin.Item);
        Console.WriteLine("Enter the name of the skin:");

        string skinName = Console.ReadLine();

        if (skinName == null)
        {
            SelectSkin(item);
        }
        else
        {
            _skin.Name = skinName;
            Selenium selenium = new Selenium();
            string skinPortPrice = selenium.GetPricesFromSkinPort(_skin);
            string skinBaronPrice = selenium.GetPricesFromSkinBaron(_skin);

            Console.Clear();
            Console.WriteLine($"{_skin.Item} | {selenium.FirstCharToUpper(_skin.Name)}");
            if (skinPortPrice == "Couldn't get price")
            {
                Console.WriteLine($"{skinPortPrice}");
            }
            else
            {
                Console.WriteLine($"SkinPort Price: CHF {skinPortPrice}");
            }

            if (skinBaronPrice == "Couldn't get price")
            {
                Console.WriteLine($"{skinBaronPrice}");
            }
            else
            {
                decimal skinBaronPriceInChf = GetCHFPriceFromEUR(Convert.ToDecimal(skinBaronPrice), "EUR").Result;
                Console.WriteLine($"SkinBaron Price: CHF {Math.Round(skinBaronPriceInChf, 2)}");
            }
        }

    }

    public async Task<decimal> GetCHFPriceFromEUR(decimal inputPrice, string currency)
    {
        string apiUrl = $"https://open.er-api.com/v6/latest/{currency}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string json = await client.GetStringAsync(apiUrl);
                JObject exchangeRates = JObject.Parse(json);

                if (exchangeRates["result"].ToString() == "success")
                {
                    decimal chfRate = (decimal)exchangeRates["rates"]["CHF"];
                    decimal chfPrice = inputPrice * chfRate;
                    return chfPrice;
                }
                else
                {
                    return 0;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error retrieving exchange rates: {ex.Message}");
            }
        }
        return 0;
    }
}
