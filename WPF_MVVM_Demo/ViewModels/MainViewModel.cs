using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using WPF_MVVM_Demo.Resources;

namespace WPF_MVVM_Demo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _selectedViewModel;

        [ObservableProperty]
        private string _currentLanguage;

        public List<LanguageItem> Languages { get; } = new()
        {
            new LanguageItem { Code = "ru-RU", Name = "Русский" },
            new LanguageItem { Code = "en-US", Name = "English" }
        };

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

            // Инициализация текущего языка
            CurrentLanguage = LocalizationService.Instance.CurrentCulture.Name;

            // Подписка на изменение языка для обновления CurrentLanguage
            LocalizationService.Instance.LanguageChanged += (s, e) =>
            {
                CurrentLanguage = LocalizationService.Instance.CurrentCulture.Name;
                OnPropertyChanged(nameof(CurrentLanguage));
            };
        }

        // Этот метод привязывается к ComboBox через SelectedValue
        partial void OnCurrentLanguageChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                LocalizationService.Instance.ChangeLanguage(value);
            }
        }

        [RelayCommand]
        private void SelectTab(object viewModel)
        {
            SelectedViewModel = viewModel;
        }

        [RelayCommand]
        private void ChangeLanguage(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode)) return;
            LocalizationService.Instance.ChangeLanguage(languageCode);
        }
    }

    public class LanguageItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}