using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using WPF_MVVM_Demo.Models;
using WPF_MVVM_Demo.Resources;

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
                FirstName = "Петр",
                LastName = "Петров",
                Age = 30,
                Email = "petr@example.com",
                IsStudent = false
            };

            InputText = LocalizationService.Instance.GetString("TwoWayBinding_TextBoxPlaceholder") ?? "Начальный текст";
            IsChecked = true;
        }

        // Partial метод вызывается автоматически при изменении InputText
        partial void OnInputTextChanged(string value)
        {
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

        [RelayCommand]
        private void SaveData()
        {
            // Локализованное сообщение
            MessageBox.Show(
                LocalizationService.Instance.GetString("Message_DataSaved"),
                LocalizationService.Instance.GetString("Message_Title_Success"),
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
    }
}