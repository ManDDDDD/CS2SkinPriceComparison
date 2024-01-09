namespace CS2SkinPriceComparison;

using Newtonsoft.Json.Linq;

public class JsonReader
{
    public static JObject LoadJson(string path)
    {
        string jsonString = File.ReadAllText(path);
        JObject jsonObject = JObject.Parse(jsonString);
        return jsonObject;
    }
}