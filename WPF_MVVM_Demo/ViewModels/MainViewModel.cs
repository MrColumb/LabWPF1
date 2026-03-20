using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CodingSeb.Localization;
using System.Collections.ObjectModel;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _selectedViewModel;

        [ObservableProperty]
        private string _currentLanguage = "en";

        public ObservableCollection<string> AvailableLanguages { get; } = new();

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

            foreach (var language in Loc.Instance.AvailableLanguages)
            {
                AvailableLanguages.Add(language);
            }

            CurrentLanguage = Loc.Instance.CurrentLanguage;
            SelectedViewModel = DefaultBindingVM;
        }

        partial void OnCurrentLanguageChanged(string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && Loc.Instance.CurrentLanguage != value)
            {
                Loc.Instance.CurrentLanguage = value;
            }
        }

        [RelayCommand]
        private void SelectTab(object viewModel)
        {
            SelectedViewModel = viewModel;
        }
    }
}