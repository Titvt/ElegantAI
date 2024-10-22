using System;
using Avalonia;
using Avalonia.Markup.Xaml;

namespace ElegantAI;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnSettingsClicked(object? sender, EventArgs e)
    {
        WindowManager.OpenSettingsWindow();
    }

    private void OnExitClicked(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}