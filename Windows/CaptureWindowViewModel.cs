using CommunityToolkit.Mvvm.ComponentModel;

namespace ElegantAI.Windows;

public partial class CaptureWindowViewModel : ObservableObject
{
    [ObservableProperty] private string _source;

    public CaptureWindowViewModel()
    {
        Source = "";
    }
}