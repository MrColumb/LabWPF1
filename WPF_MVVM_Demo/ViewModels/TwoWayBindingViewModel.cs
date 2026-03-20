using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class TwoWayBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private Person _person;

        [ObservableProperty]
        private string _inputText;

        [ObservableProperty]
        private bool _isChecked;

        // Вычисляемое свойство
        public int TextLength => InputText?.Length ?? 0;

        public TwoWayBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Age = 30,
                Email = "petr@example.com",
                IsStudent = false
            };

            InputText = "Initial text";
            IsChecked = true;
        }

        // Partial метод вызывается автоматически при изменении InputText
        partial void OnInputTextChanged(string value)
        {
            // Уведомляем об изменении TextLength
            OnPropertyChanged(nameof(TextLength));
        }

        [RelayCommand]
        private void ClearInput()
        {
            InputText = string.Empty;
        }

        [RelayCommand]
        private void ToggleCheck()
        {
            IsChecked = !IsChecked;
        }
    }
}