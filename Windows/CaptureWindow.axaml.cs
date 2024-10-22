using Avalonia.Controls;
using Avalonia.Input;

namespace ElegantAI.Windows;

public partial class CaptureWindow : Window
{
    public CaptureWindow()
    {
        InitializeComponent();
        DataContext = new CaptureWindowViewModel();
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Close();
        }
    }
}