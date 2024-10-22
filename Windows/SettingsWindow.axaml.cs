using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ElegantAI.Windows;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
        DataContext = new SettingsWindowViewModel();
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        if (change.Property == WindowStateProperty)
        {
            Padding = change.NewValue as WindowState? == WindowState.Maximized ? new Thickness(8, 31, 8, 23) : new Thickness(0, 30, 0, 15);
        }

        base.OnPropertyChanged(change);
    }

    private void OnSaveClicked(object? sender, RoutedEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel viewModel)
        {
            viewModel.Save();
        }
    }
}