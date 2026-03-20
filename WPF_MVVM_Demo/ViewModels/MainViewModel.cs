namespace WPF_MVVM_Demo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _selectedViewModel;

        public DefaultBindingViewModel DefaultBindingVM { get; }
        public TwoWayBindingViewModel TwoWayBindingVM { get; }
        public OneTimeBindingViewModel OneTimeBindingVM { get; }
        public OneWayBindingViewModel OneWayBindingVM { get; }
        public TriggersViewModel TriggersVM { get; }

        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public MainViewModel()
        {
            DefaultBindingVM = new DefaultBindingViewModel();
            TwoWayBindingVM = new TwoWayBindingViewModel();
            OneTimeBindingVM = new OneTimeBindingViewModel();
            OneWayBindingVM = new OneWayBindingViewModel();
            TriggersVM = new TriggersViewModel();

            SelectedViewModel = DefaultBindingVM;
        }
    }
}