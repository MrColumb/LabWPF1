using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class OneTimeBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private Person _person;

        [ObservableProperty]
        private DateTime _currentTime;

        [ObservableProperty]
        private string _staticText;

        public OneTimeBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "Sergey",
                LastName = "Sergeev",
                Age = 35,
                Email = "sergey@example.com",
                IsStudent = false
            };

            CurrentTime = DateTime.Now;
            StaticText = "This text does not change after updates";
        }

        [RelayCommand]
        private void UpdateTime()
        {
            CurrentTime = DateTime.Now;
        }

        [RelayCommand]
        private void UpdatePersonName(string newName)
        {
            Person.FirstName = newName;
            OnPropertyChanged(nameof(Person));
        }
    }
}