using System.ComponentModel;

namespace BasicMvvmSample.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}