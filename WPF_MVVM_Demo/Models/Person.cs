using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM_Demo.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _email;
        private bool _isStudent;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);

            // При изменении FirstName или LastName, уведомляем об изменении FullName
            if (propertyName == nameof(FirstName) || propertyName == nameof(LastName))
            {
                OnPropertyChanged(nameof(FullName));
            }

            return true;
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public bool IsStudent
        {
            get => _isStudent;
            set => SetProperty(ref _isStudent, value);
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}