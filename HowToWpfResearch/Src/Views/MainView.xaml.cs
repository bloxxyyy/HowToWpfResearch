using System.Windows;

using HowToWpfResearch.Src.ViewModels;

namespace HowToWpfResearch.Src.Views;

public partial class MainView : Window
{
    public MainView(MainViewModel vm) {
        InitializeComponent();
        DataContext = vm;
    }
}
