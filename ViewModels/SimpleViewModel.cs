using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicMvvmSample.ViewModels
{
    // Наследуется от класса, который отвечает за уведомление View, если  
    // измениться какое-либо свойство 
    public class SimpleViewModel : INotifyPropertyChanged
    {
        // Метод (Колбэк по сути), который будет обрабатывать наше событие
        // Ему нужно присвоить реализацию обработчика (PropertyChanged +=)
        public event PropertyChangedEventHandler? PropertyChanged;

        // Функция-член, вызывающая событие PropertyChanged. По сути для того, чтобы
        // вызывать наш event вручную. В этом примере атрибут [CallerMemberName] применяется 
        // к параметру propertyName. Когда этот метод вызывается из свойства, компилятор автоматически 
        // передает имя этого свойства в качестве аргумента propertyName.
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // Вызывает event PropertyChanged. Проверяет его на null (Invoke). 
            // * this: Ссылка на сам объект, в котором изменяется свойство.
            // * new PropertyChangedEventArgs(propertyName): Экземпляр класса PropertyChangedEventArgs, 
            // который содержит имя измененного свойства (propertyName).
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? _Name;
        public string? Name
        {
            get => _Name;
            set
            {  
                if (_Name != value)
                {
                    _Name = value;

                    // Мы вызываем RaisePropertyChanged(), чтобы уведомить пользовательский интерфейс об изменениях. 
                    // Мы можем опустить здесь имя свойства, поскольку [CallerMemberName] предоставит его нам.
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Greeting));
                }
            }
        }

        public string? Greeting
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    // If no Name is provided, use a default Greeting
                    return "Hello World from Avalonia.Samples";
                }
                else
                {
                    // else greet the User.
                    return $"Hello {Name}";
                }
            }
        }
    }

}