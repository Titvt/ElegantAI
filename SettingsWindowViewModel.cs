using CommunityToolkit.Mvvm.ComponentModel;

namespace ElegantAI;

public partial class SettingsWindowViewModel : ObservableObject
{
    [ObservableProperty] private string _baseUrl;
    [ObservableProperty] private string _apiKey;
    [ObservableProperty] private string _model;

    public SettingsWindowViewModel()
    {
        var config = Program.GetConfig();
        BaseUrl = config.BaseUrl;
        ApiKey = config.ApiKey;
        Model = config.Model;
    }

    public void Save()
    {
        var config = new Config
        {
            BaseUrl = BaseUrl,
            ApiKey = ApiKey,
            Model = Model
        };
        Program.SetConfig(config);
    }
}