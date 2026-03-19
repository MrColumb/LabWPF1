using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF_MVVM_Demo.Models
{
    public partial class Person : ObservableObject
    {
        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private int _age;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private bool _isStudent;

        public string FullName => $"{FirstName} {LastName}";

        // Эти методы автоматически вызываются при изменении свойств
        partial void OnFirstNameChanged(string value)
        {
            OnPropertyChanged(nameof(FullName));
        }

        partial void OnLastNameChanged(string value)
        {
            OnPropertyChanged(nameof(FullName));
        }
    }
}