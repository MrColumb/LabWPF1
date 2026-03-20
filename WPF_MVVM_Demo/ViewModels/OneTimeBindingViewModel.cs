using WPF_MVVM_Demo.Models;
using System;

namespace WPF_MVVM_Demo.ViewModels
{
    public class OneTimeBindingViewModel : ViewModelBase
    {
        private Person _person;
        private DateTime _currentTime;
        private string _staticText;

        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetProperty(ref _currentTime, value);
        }

        public string StaticText
        {
            get => _staticText;
            set => SetProperty(ref _staticText, value);
        }

        public OneTimeBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "Сергей",
                LastName = "Сергеев",
                Age = 35,
                Email = "sergey@example.com",
                IsStudent = false
            };

            CurrentTime = DateTime.Now;
            StaticText = "Этот текст не изменится при обновлении";
        }

        public void UpdateTime()
        {
            CurrentTime = DateTime.Now;
            OnPropertyChanged(nameof(CurrentTime));
        }
    }
}