using System;
using Avalonia;
using Avalonia.Controls;

namespace ElegantAI;

public partial class SettingsWindow : Window
{
    private static SettingsWindow? _instance;

    private SettingsWindow()
    {
        InitializeComponent();
        DataContext = new SettingsWindowViewModel();
    }

    public static void Open()
    {
        if (_instance is not null)
        {
            if (_instance.WindowState == WindowState.Minimized)
            {
                _instance.WindowState = WindowState.Normal;
            }

            _instance.Activate();
        }
        else
        {
            _instance = new SettingsWindow();
            _instance.Closed += (_, _) => _instance = null;
            _instance.Show();
        }
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        if (change.Property == WindowStateProperty)
        {
            Padding = change.NewValue as WindowState? == WindowState.Maximized ? new Thickness(8, 31, 8, 8) : new Thickness(0, 30, 0, 0);
        }

        base.OnPropertyChanged(change);
    }

    private void OnBaseUrlChanged(object? sender, TextChangedEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel viewModel)
        {
            Console.WriteLine(viewModel.BaseUrl);
        }
    }

    private void OnApiKeyChanged(object? sender, TextChangedEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel viewModel)
        {
            Console.WriteLine(viewModel.ApiKey);
        }
    }
}