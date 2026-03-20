using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class OneWayBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private Person _person;

        [ObservableProperty]
        private string _readOnlyText;

        [ObservableProperty]
        private int _counter;

        public OneWayBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "Anna",
                LastName = "Smirnova",
                Age = 28,
                Email = "anna@example.com",
                IsStudent = true
            };

            ReadOnlyText = "This text is read-only";
            Counter = 0;
        }

        [RelayCommand]
        private void IncrementCounter()
        {
            Counter++;
        }

        [RelayCommand]
        private void DecrementCounter()
        {
            Counter--;
        }

        [RelayCommand]
        private void UpdatePerson(string parameter)
        {
            switch (parameter)
            {
                case "name":
                    Person.FirstName = "New Name";
                    break;
                case "age":
                    Person.Age++;
                    break;
                default:
                    Person.FirstName = "Updated Name";
                    Person.Age++;
                    break;
            }
            OnPropertyChanged(nameof(Person));
        }
    }
}