using CommunityToolkit.Mvvm.ComponentModel;

namespace ElegantAI;

public partial class SettingsWindowViewModel : ObservableObject
{
    [ObservableProperty] private string _baseUrl;
    [ObservableProperty] private string _apiKey;

    public SettingsWindowViewModel()
    {
        var config = Program.GetConfig();
        BaseUrl = config.BaseUrl;
        ApiKey = config.ApiKey;
    }

    public void Save()
    {
        var config = new Config
        {
            BaseUrl = BaseUrl,
            ApiKey = ApiKey
        };
        Program.SetConfig(config);
    }
}