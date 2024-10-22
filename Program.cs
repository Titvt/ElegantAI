using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace ElegantAI;

public static class Program
{
    public static void Main(string[] args)
    {
        HotKey.Register(Key.F1, KeyModifiers.None, WindowManager.OpenCaptureWindow);
        AppBuilder.Configure<App>().UsePlatformDetect().WithInterFont().Start(AppMain, args);
    }

    private static void AppMain(Application app, string[] args)
    {
        var tokenSource = new CancellationTokenSource();
        app.Run(tokenSource.Token);
    }
}