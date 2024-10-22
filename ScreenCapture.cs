using System.IO;
using System.Linq;
using HPPH;
using HPPH.SkiaSharp;
using ScreenCapture.NET;

namespace ElegantAI;

public static class ScreenCapture
{
    private static readonly ScreenCapturerContext Context;

    static ScreenCapture()
    {
        var captureService = new DX11ScreenCaptureService();
        var graphicsCard = captureService.GetGraphicsCards().First();
        var display = captureService.GetDisplays(graphicsCard).First();
        var screenCapture = captureService.GetScreenCapture(display);
        var captureZone = screenCapture.RegisterCaptureZone(0, 0, screenCapture.Display.Width, screenCapture.Display.Height);
        Context = new ScreenCapturerContext
        {
            CaptureService = captureService,
            GraphicsCard = graphicsCard,
            Display = display,
            ScreenCapture = screenCapture,
            CaptureZone = captureZone
        };
        Context.ScreenCapture.CaptureScreen();
    }

    public static Stream CaptureScreen()
    {
        Context.ScreenCapture.CaptureScreen();

        using (Context.CaptureZone.Lock())
        {
            return new MemoryStream(Context.CaptureZone.Image.ToPng());
        }
    }
}

public struct ScreenCapturerContext
{
    public DX11ScreenCaptureService CaptureService;
    public GraphicsCard GraphicsCard;
    public Display Display;
    public DX11ScreenCapture ScreenCapture;
    public CaptureZone<ColorBGRA> CaptureZone;
}