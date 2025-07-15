using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HowToWpfResearch.Src.ViewModels;

public partial class MainViewModel : ObservableObject {
    private readonly HomeViewModel _homeVm;
    private readonly SettingsViewModel _settingsVm;

    [ObservableProperty]
    private ObservableObject currentViewModel;

    public MainViewModel(HomeViewModel homeVm, SettingsViewModel settingsVm)
    {
        _homeVm = homeVm;
        _settingsVm = settingsVm;
        CurrentViewModel = _homeVm;
    }

    [RelayCommand]
    private void NavigateHome() => CurrentViewModel = _homeVm;

    [RelayCommand]
    private void NavigateSettings() => CurrentViewModel = _settingsVm;
}
