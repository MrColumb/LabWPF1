using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class TriggersViewModel : ObservableObject
    {
        [ObservableProperty]
        private Person _person;

        [ObservableProperty]
        private bool _isSpecial;

        [ObservableProperty]
        private int _progress;

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
        }

        [RelayCommand]
        private void ToggleSpecial()
        {
            IsSpecial = !IsSpecial;
        }

        [RelayCommand]
        private void IncreaseProgress()
        {
            if (Progress < 100)
                Progress += 10;
        }

        [RelayCommand]
        private void DecreaseProgress()
        {
            if (Progress > 0)
                Progress -= 10;
        }

        // Partial метод для реакции на изменение Progress
        partial void OnProgressChanged(int value)
        {
            // Можно добавить логику
        }
    }
}