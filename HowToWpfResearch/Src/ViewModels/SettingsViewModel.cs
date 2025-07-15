using CommunityToolkit.Mvvm.ComponentModel;

namespace HowToWpfResearch.Src.ViewModels;

public partial class SettingsViewModel : ObservableObject {
    public SettingsViewModel() {
        Message = "Loaded succesfully";
    }

    [ObservableProperty]
    private string message;
}