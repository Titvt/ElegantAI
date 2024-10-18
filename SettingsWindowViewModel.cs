using CommunityToolkit.Mvvm.ComponentModel;

namespace ElegantAI;

public partial class SettingsWindowViewModel : ObservableObject
{
    [ObservableProperty] private string _baseUrl = "";
    [ObservableProperty] private string _apiKey = "";
}