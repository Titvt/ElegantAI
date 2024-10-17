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

    private void Exit(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}