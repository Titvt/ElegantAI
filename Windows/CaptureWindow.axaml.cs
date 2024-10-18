using Avalonia.Controls;
using Avalonia.Input;

namespace ElegantAI.Windows;

public partial class CaptureWindow : Window
{
    private static CaptureWindow? _instance;

    private CaptureWindow()
    {
        InitializeComponent();
        DataContext = new CaptureWindowViewModel();
    }

    public static void Capture()
    {
        if (_instance is not null)
        {
            _instance.Close();
        }
        else
        {
            _instance = new CaptureWindow();
            _instance.Closed += (_, _) => _instance = null;
            _instance.Show();
        }
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Close();
        }
    }
}