using System;
using System.IO;
using System.Text.Json;

namespace ElegantAI;

public class Config
{
    private static Config _config = new();
    public string BaseUrl { get; init; } = "https://api.openai.com";
    public string ApiKey { get; init; } = "";
    public string Model { get; init; } = "gpt-4o";

    static Config()
    {
        try
        {
            var path = Path.Combine(AppContext.BaseDirectory, "config.json");
            var json = File.ReadAllText(path);
            _config = JsonSerializer.Deserialize<Config>(json) ?? throw new Exception();
        }
        catch
        {
            SetConfig(_config);
        }
    }

    public static Config GetConfig()
    {
        return _config;
    }

    public static void SetConfig(Config config)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "config.json");
        var contents = JsonSerializer.Serialize(config);
        File.WriteAllText(path, contents);
        _config = config;
    }
}