using System;
using Avalonia;
using Avalonia.Markup.Xaml;
using ElegantAI.Windows;

namespace ElegantAI;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnSettingsClicked(object? sender, EventArgs e)
    {
        SettingsWindow.Open();
    }

    private void OnExitClicked(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}