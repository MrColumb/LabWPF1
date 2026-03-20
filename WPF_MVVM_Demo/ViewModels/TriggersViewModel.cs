using WPF_MVVM_Demo.Models;
using System.Windows.Input;

namespace WPF_MVVM_Demo.ViewModels
{
    public class TriggersViewModel : ViewModelBase
    {
        private Person _person;
        private bool _isSpecial;
        private int _progress;

        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        public bool IsSpecial
        {
            get => _isSpecial;
            set => SetProperty(ref _isSpecial, value);
        }

        public int Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public ICommand ToggleSpecialCommand { get; }
        public ICommand IncreaseProgressCommand { get; }
        public ICommand DecreaseProgressCommand { get; }

        public TriggersViewModel()
        {
            Person = new Person
            {
                FirstName = "Тестовый",
                LastName = "Пользователь",
                Age = 40,
                Email = "test@example.com",
                IsStudent = false
            };

            Progress = 50;

            ToggleSpecialCommand = new RelayCommand(ToggleSpecial);
            IncreaseProgressCommand = new RelayCommand(IncreaseProgress);
            DecreaseProgressCommand = new RelayCommand(DecreaseProgress);
        }

        private void ToggleSpecial()
        {
            IsSpecial = !IsSpecial;
        }

        private void IncreaseProgress()
        {
            if (Progress < 100)
                Progress += 10;
        }

        private void DecreaseProgress()
        {
            if (Progress > 0)
                Progress -= 10;
        }
    }

    // Простая реализация RelayCommand
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { System.Windows.Input.CommandManager.RequerySuggested += value; }
            remove { System.Windows.Input.CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}