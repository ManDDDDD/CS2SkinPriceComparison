namespace CS2SkinPriceComparison;
using Newtonsoft.Json.Linq;


public class UserInput
{
    private static JObject _jsonItems = JsonReader.LoadJson("../../../Items.json");
    private static IList<string> keys = _jsonItems.Properties().Select(p => p.Name).ToList();
    public Skin skin = new Skin();
    public void SelectItemType()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {keys[i]}");
        }

        string selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                skin.Category = "Gun Skin";
                SelectSubType((JObject)_jsonItems["Gun Skin"]);
                break;
            case "2":
                skin.Category = "Knife";
                SelectSubType((JObject)_jsonItems["Knife"]);
                break;
            case "3":
                skin.Category = "Gloves";
                SelectSubType((JObject)_jsonItems["Gloves"]);
                break;
            case "4":
                skin.Category = "Container";
                SelectSubType((JObject)_jsonItems["Container"]);
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
        Console.WriteLine("Select a Gun Type:");
        foreach (string item in subTypeKey)
        {
            Console.WriteLine($"{index}. {item}");
            index++;
        }
        string selection = Console.ReadLine();
        
        if(!int.TryParse(selection, out int intSelection))
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
            if(subType[selectedSubType] is JObject)
            {
                skin.SubCategory = selectedSubType;
                SelectSubType((JObject)subType[selectedSubType]);
            }
            else if(subType[selectedSubType] is JValue)
            {
                skin.Item = subType[selectedSubType];
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
        Console.WriteLine("Enter the name of the skin (Case Sensitive):");

        string skinName = Console.ReadLine();

        if (skinName == null)
        {
            SelectSkin(item);
        }
        else
        {
            skin.Name = skinName;
            Selenium selenium = new Selenium();
            string skinPortPrice = selenium.GetPricesFromSkinPort(skin);
            string skinBaronPrice = selenium.GetPricesFromSkinBaron(skin);
            string steamPrice = selenium.GetPricesFromSteam(skin);

            Console.WriteLine($"SkinPort Price: {skinPortPrice}");
            Console.WriteLine($"SkinBaron Price: {skinBaronPrice}");
            Console.WriteLine($"Steam Price: {steamPrice}");
        }
        
    } 
}