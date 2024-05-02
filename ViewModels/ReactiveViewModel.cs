using ReactiveUI;
using System;

namespace BasicMvvmSample.ViewModels
{
    public class ReactiveViewModel : ReactiveObject
    {
        public ReactiveViewModel()
        {
            this.WhenAnyValue(o => o.Name)
                .Subscribe(o => this.RaisePropertyChanged(nameof(Greeting)));
        }

        private string? _Name;

        public string? Name
        {
            get => _Name;
            set
            {
                this.RaiseAndSetIfChanged(ref _Name, value);
            }
        }

        public string Greeting
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "Hello from Avalonia.Samples";
                }
                else
                {
                    return $"Hello {Name}";
                }
            }
        }
    }
}
