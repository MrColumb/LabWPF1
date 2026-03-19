using WPF_MVVM_Demo.Models;
using System;

namespace WPF_MVVM_Demo.ViewModels
{
    public class OneWayBindingViewModel : ViewModelBase
    {
        private Person _person;
        private string _readOnlyText;
        private int _counter;

        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        public string ReadOnlyText
        {
            get => _readOnlyText;
            set => SetProperty(ref _readOnlyText, value);
        }

        public int Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);
        }

        public OneWayBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "Анна",
                LastName = "Смирнова",
                Age = 28,
                Email = "anna@example.com",
                IsStudent = true
            };

            ReadOnlyText = "Этот текст только для чтения";
            Counter = 0;
        }

        public void IncrementCounter()
        {
            Counter++;
        }
    }
}