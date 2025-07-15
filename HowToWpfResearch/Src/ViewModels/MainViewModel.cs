using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HowToWpfResearch.Src.ViewModels;

public partial class MainViewModel : ObservableObject {

    [ObservableProperty]
    private string greeting = "Hello, WPF + CommunityToolkit!";

    [RelayCommand]
    private void UpdateGreeting() {
        Greeting = "You clicked the button!";
    }

}