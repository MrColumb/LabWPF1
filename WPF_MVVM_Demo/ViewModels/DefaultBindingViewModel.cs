using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class DefaultBindingViewModel : ObservableObject  // Убираем наследование от ViewModelBase
    {
        [ObservableProperty]  // Авто-свойство
        private Person _person;

        [ObservableProperty]
        private string _directText;

        [ObservableProperty]
        private string _vmText;

        public DefaultBindingViewModel()
        {
            Person = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 25,
                Email = "ivan@example.com",
                IsStudent = false
            };

            DirectText = "Text from UI";
            VmText = "Text from ViewModel";
        }
    }
}