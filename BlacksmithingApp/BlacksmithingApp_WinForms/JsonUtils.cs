using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlacksmithingApp_WinForms;

public class JsonUtils
{
    private static readonly JsonSerializerOptions _options = 
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    
    public static void SimpleWrite(object obj, string fileName)
    {
        var jsonString = JsonSerializer.Serialize(obj, _options);
        File.WriteAllText(fileName, jsonString);
    }

    public static List<BladeCost> SimpleReadBlades(string fileName)
    {
        var jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<BladeCost>>(jsonString, _options);
    }
    public static List<GuardCost> SimpleReadGuards(string fileName)
    {
        var jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<GuardCost>>(jsonString, _options);
    }
    public static List<HiltCost> SimpleReadHilts(string fileName)
    {
        var jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<HiltCost>>(jsonString, _options);
    }
}