using System.Threading;
using Avalonia;
using Avalonia.Controls;

namespace ElegantAI;

public static class Program
{
    public static void Main(string[] args)
    {
        AppBuilder.Configure<App>().UsePlatformDetect().WithInterFont().Start(AppMain, args);
    }

    private static void AppMain(Application app, string[] args)
    {
        var tokenSource = new CancellationTokenSource();
        app.Run(tokenSource.Token);
    }
}