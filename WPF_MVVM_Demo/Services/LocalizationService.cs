using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace WPF_MVVM_Demo.Services
{
    public static class LocalizationService
    {
        private static ResourceDictionary _currentDictionary;
        private static ResourceDictionary _ruDictionary;
        private static ResourceDictionary _enDictionary;

        public static event EventHandler LanguageChanged;

        public static CultureInfo CurrentCulture { get; private set; }

        static LocalizationService()
        {
            try
            {
                // Загружаем словари
                _ruDictionary = new ResourceDictionary
                {
                    Source = new Uri("/WPF_MVVM_Demo;component/Resources/Localization/Localization.ru.xaml", UriKind.RelativeOrAbsolute)
                };
                _enDictionary = new ResourceDictionary
                {
                    Source = new Uri("/WPF_MVVM_Demo;component/Resources/Localization/Localization.en.xaml", UriKind.RelativeOrAbsolute)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки словарей локализации: {ex.Message}");
            }
        }

        public static void Initialize()
        {
            // Устанавливаем русский язык по умолчанию
            SetLanguage("ru");
        }

        public static void SetLanguage(string languageCode)
        {
            ResourceDictionary newDictionary = null;

            switch (languageCode.ToLower())
            {
                case "ru":
                    newDictionary = _ruDictionary;
                    CurrentCulture = new CultureInfo("ru-RU");
                    break;
                case "en":
                    newDictionary = _enDictionary;
                    CurrentCulture = new CultureInfo("en-US");
                    break;
                default:
                    newDictionary = _ruDictionary;
                    CurrentCulture = new CultureInfo("ru-RU");
                    break;
            }

            // Устанавливаем культуру для форматирования
            Thread.CurrentThread.CurrentCulture = CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CurrentCulture;

            // Находим и удаляем старый словарь локализации
            ResourceDictionary oldDictionary = null;
            foreach (var dict in Application.Current.Resources.MergedDictionaries)
            {
                if (dict.Source != null && (dict.Source.OriginalString.Contains("Localization.ru") || dict.Source.OriginalString.Contains("Localization.en")))
                {
                    oldDictionary = dict;
                    break;
                }
            }

            if (oldDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
            }

            // Добавляем новый словарь
            if (newDictionary != null && !Application.Current.Resources.MergedDictionaries.Contains(newDictionary))
            {
                Application.Current.Resources.MergedDictionaries.Add(newDictionary);
            }

            _currentDictionary = newDictionary;
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}