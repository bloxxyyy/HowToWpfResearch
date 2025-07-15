using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using HowToWpfResearch.Src.Services;

namespace HowToWpfResearch.Src.ViewModels;

public partial class MainViewModel : ObservableObject {

    private readonly IGreetingService _greetingService;

    public MainViewModel(IGreetingService greetingService) {
        _greetingService = greetingService;
        Greeting         = "Press the button to load the greeting.";
    }

    [ObservableProperty]
    private string greeting;

    [RelayCommand]
    private void LoadGreeting() {
        Greeting = _greetingService.GetGreeting().Message;
    }

}
