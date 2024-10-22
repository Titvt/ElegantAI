using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using HPPH;
using HPPH.SkiaSharp;
using ScreenCapture.NET;

namespace ElegantAI;

public static class Program
{
    private static Config _config = new();
    private static DX11ScreenCapture _screenCapture = null!;
    private static CaptureZone<ColorBGRA> _captureZone = null!;

    public static void Main(string[] args)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "config.json");

        try
        {
            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<Config>(json)!;
            _config = config;
        }
        catch
        {
            SetConfig(_config);
        }

        var captureService = new DX11ScreenCaptureService();
        var graphicsCards = captureService.GetGraphicsCards();
        var displays = captureService.GetDisplays(graphicsCards.First());
        _screenCapture = captureService.GetScreenCapture(displays.First());
        _captureZone = _screenCapture.RegisterCaptureZone(0, 0, _screenCapture.Display.Width, _screenCapture.Display.Height);
        AppBuilder.Configure<App>().UsePlatformDetect().WithInterFont().Start(AppMain, args);
    }

    private static void AppMain(Application app, string[] args)
    {
        var tokenSource = new CancellationTokenSource();
        app.Run(tokenSource.Token);
    }

    public static Config GetConfig()
    {
        return _config;
    }

    public static void SetConfig(Config config)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "config.json");
        var json = JsonSerializer.Serialize(config);
        File.WriteAllText(path, json);
        _config = config;
    }

    public static Stream CaptureScreen()
    {
        _screenCapture.CaptureScreen();

        using (_captureZone.Lock())
        {
            return new MemoryStream(_captureZone.Image.ToPng());
        }
    }
}

public class Config
{
    public string BaseUrl { get; init; } = "https://api.openai.com";
    public string ApiKey { get; init; } = "";
    public string Model { get; init; } = "gpt-4o";
}