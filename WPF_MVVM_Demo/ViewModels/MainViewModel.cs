using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class MainViewModel : ObservableObject  // Наследуемся от ObservableObject
    {
        [ObservableProperty]  // Атрибут для авто-генерации свойства
        private object _selectedViewModel;

        public DefaultBindingViewModel DefaultBindingVM { get; }
        public TwoWayBindingViewModel TwoWayBindingVM { get; }
        public OneTimeBindingViewModel OneTimeBindingVM { get; }
        public OneWayBindingViewModel OneWayBindingVM { get; }
        public TriggersViewModel TriggersVM { get; }

        public MainViewModel()
        {
            DefaultBindingVM = new DefaultBindingViewModel();
            TwoWayBindingVM = new TwoWayBindingViewModel();
            OneTimeBindingVM = new OneTimeBindingViewModel();
            OneWayBindingVM = new OneWayBindingViewModel();
            TriggersVM = new TriggersViewModel();

            SelectedViewModel = DefaultBindingVM;
        }

        [RelayCommand]  // Автоматически создает команду SelectTabCommand
        private void SelectTab(object viewModel)
        {
            SelectedViewModel = viewModel;
        }
    }
}