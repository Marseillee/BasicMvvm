namespace BasicMvvmSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();

#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
}
