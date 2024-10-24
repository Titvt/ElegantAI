using System.IO;
using System.Linq;
using Avalonia.Media.Imaging;
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
        screenCapture.CaptureScreen();
        Context = new ScreenCapturerContext
        {
            CaptureService = captureService,
            GraphicsCard = graphicsCard,
            Display = display,
            ScreenCapture = screenCapture,
            CaptureZone = captureZone
        };
    }

    public static Bitmap CaptureScreen()
    {
        Context.ScreenCapture.CaptureScreen();

        using (Context.CaptureZone.Lock())
        {
            var buffer = Context.CaptureZone.Image.ToPng();
            using var memoryStream = new MemoryStream(buffer);
            var bitmap = new Bitmap(memoryStream);
            return bitmap;
        }
    }

    private struct ScreenCapturerContext
    {
        public DX11ScreenCaptureService CaptureService;
        public GraphicsCard GraphicsCard;
        public Display Display;
        public DX11ScreenCapture ScreenCapture;
        public CaptureZone<ColorBGRA> CaptureZone;
    }
}