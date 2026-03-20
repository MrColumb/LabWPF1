using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Data;

namespace WPF_MVVM_Demo.Resources
{
    public class LocalizationExtension : MarkupExtension
    {
        public string Key { get; set; }

        public LocalizationExtension()
        {
        }

        public LocalizationExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
                return "[Key missing]";

            // Создаем объект-источник с поддержкой уведомлений
            var source = new LocalizationBindingSource(Key);

            // Создаем привязку
            var binding = new Binding
            {
                Source = source,
                Path = new PropertyPath("Value"),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            return binding.ProvideValue(serviceProvider);
        }
    }

    public class LocalizationBindingSource : INotifyPropertyChanged
    {
        private string _key;
        private string _cachedValue;

        public LocalizationBindingSource(string key)
        {
            _key = key;
            _cachedValue = LocalizationService.Instance.GetString(_key);

            // Подписываемся на изменение языка
            LocalizationService.Instance.LanguageChanged += (s, e) =>
            {
                _cachedValue = LocalizationService.Instance.GetString(_key);
                OnPropertyChanged(nameof(Value));
            };
        }

        public string Value => _cachedValue;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}