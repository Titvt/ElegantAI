using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ElegantAI.Windows;

public partial class CaptureWindowViewModel : ObservableObject
{
    [ObservableProperty] private Bitmap _source;

    public CaptureWindowViewModel()
    {
        var bitmap = ScreenCapture.CaptureScreen();
        Source = bitmap;
    }
}