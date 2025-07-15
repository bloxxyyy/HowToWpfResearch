using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HowToWpfResearch.Src.Design;

public partial class DesignMainViewModel : ObservableObject {
    [ObservableProperty]
    private string greeting = "Hello from Design Mode!";

    [RelayCommand]
    private void LoadGreeting() {
        Greeting = "Designer Clicked!";
    }
}
