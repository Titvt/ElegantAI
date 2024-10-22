using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ElegantAI.Windows;

public partial class CaptureWindowViewModel : ObservableObject
{
    [ObservableProperty] private Bitmap _source;

    public CaptureWindowViewModel()
    {
        using var stream = Program.CaptureScreen();
        Source = new Bitmap(stream);
    }
}