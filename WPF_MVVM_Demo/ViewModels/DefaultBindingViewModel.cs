using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public class DefaultBindingViewModel : ViewModelBase
    {
        private Person _person;
        private string _directText;
        private string _vmText;

        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        public string DirectText
        {
            get => _directText;
            set => SetProperty(ref _directText, value);
        }

        public string VMText
        {
            get => _vmText;
            set => SetProperty(ref _vmText, value);
        }

        public DefaultBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Age = 25,
                Email = "ivan@example.com",
                IsStudent = false
            };

            DirectText = "Текст из интерфейса";
            VMText = "Текст из ViewModel";
        }
    }
}