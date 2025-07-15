using HowToWpfResearch.Src.Models;

namespace HowToWpfResearch.Src.Services;

public partial class GreetingService : IGreetingService {
    public GreetingModel GetGreeting() {
        return new GreetingModel {
            Message = "Hello from the GreetingService!"
        };
    }
}