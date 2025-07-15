using System.Windows;

using HowToWpfResearch.Src.ViewModels;
using HowToWpfResearch.Src.Views;

using Microsoft.Extensions.DependencyInjection;

namespace HowToWpfResearch.Src {
    public partial class App : Application {

        public IServiceProvider Services { get; }

        public new static App Current => (App)Application.Current;

        public App() {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices() {
            ServiceCollection services = new();

            // Register your viewmodels here
            services.AddTransient<MainViewModel>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            MainViewModel mainViewModel = Services.GetRequiredService<MainViewModel>();

            MainView mainView = new() {
                DataContext = mainViewModel
            };

            mainView.Show();
        }
    }
}
