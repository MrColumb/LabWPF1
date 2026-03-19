using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public class TwoWayBindingViewModel : ViewModelBase
    {
        private Person _person;
        private string _inputText;
        private bool _isChecked;

        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }

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

            InputText = "Начальный текст";
            IsChecked = true;
        }
    }
}