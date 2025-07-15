using CommunityToolkit.Mvvm.ComponentModel;

namespace HowToWpfResearch.Src.Design;

public partial class DesignSettingsViewModel : ObservableObject {
    [ObservableProperty]
    private string message = "Hello from Design Settings ViewModel!";
}