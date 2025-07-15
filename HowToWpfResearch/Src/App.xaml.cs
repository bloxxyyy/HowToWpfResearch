using System.Windows;

using HowToWpfResearch.Src.Services;
using HowToWpfResearch.Src.ViewModels;
using HowToWpfResearch.Src.Views;

using Microsoft.Extensions.DependencyInjection;

namespace HowToWpfResearch.Src;

public partial class App : Application {
    public IServiceProvider Services { get; }

    public new static App Current => (App)Application.Current;

    public App() {
        Services = ConfigureServices();
    }

    private static ServiceProvider ConfigureServices() {
        ServiceCollection services = new();

        // Register ViewModels
        services.AddTransient<MainViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SettingsViewModel>();

        // Register Views
        services.AddTransient<MainView>();
        services.AddTransient<HomeView>();
        services.AddTransient<SettingsView>();

        //Register Services
        services.AddSingleton<IGreetingService, GreetingService>();

        return services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        MainViewModel mainViewModel = Services.GetRequiredService<MainViewModel>();
        MainView mainView = new(mainViewModel);

        mainView.Show();
    }
}
