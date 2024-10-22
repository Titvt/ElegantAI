using Avalonia.Controls;
using ElegantAI.Windows;

namespace ElegantAI;

public static class WindowManager
{
    private static CaptureWindow? _captureWindow;
    private static SettingsWindow? _settingsWindow;

    public static void OpenCaptureWindow()
    {
        if (_captureWindow is not null)
        {
            _captureWindow.Close();
        }
        else
        {
            _captureWindow = new CaptureWindow();
            _captureWindow.Closed += (_, _) => _captureWindow = null;
            _captureWindow.Show();
        }
    }

    public static void OpenSettingsWindow()
    {
        if (_settingsWindow is not null)
        {
            if (_settingsWindow.WindowState == WindowState.Minimized)
            {
                _settingsWindow.WindowState = WindowState.Normal;
            }

            _settingsWindow.Activate();
        }
        else
        {
            _settingsWindow = new SettingsWindow();
            _settingsWindow.Closed += (_, _) => _settingsWindow = null;
            _settingsWindow.Show();
        }
    }
}