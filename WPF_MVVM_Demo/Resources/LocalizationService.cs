using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows;

namespace WPF_MVVM_Demo.Resources
{
    public class LocalizationService
    {
        private static LocalizationService _instance;
        private ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public static LocalizationService Instance => _instance ??= new LocalizationService();

        public event EventHandler LanguageChanged;

        private LocalizationService()
        {
            _resourceManager = new ResourceManager("WPF_MVVM_Demo.Resources.Strings", typeof(LocalizationService).Assembly);
            _currentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = _currentCulture;

            // ВАЖНО: устанавливаем культуру для Strings.Designer.cs
            Strings.Culture = _currentCulture;
        }

        public string GetString(string key)
        {
            try
            {
                // Используем Strings.Designer.cs для получения локализованной строки
                // Это более надежный способ
                var property = typeof(Strings).GetProperty(key);
                if (property != null)
                {
                    return property.GetValue(null) as string;
                }

                // Fallback через ResourceManager
                string result = _resourceManager.GetString(key, _currentCulture);
                return string.IsNullOrEmpty(result) ? $"[{key}]" : result;
            }
            catch
            {
                return $"[{key}]";
            }
        }

        public void ChangeLanguage(string cultureCode)
        {
            if (_currentCulture.Name == cultureCode) return;

            _currentCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = _currentCulture;

            // ВАЖНО: обновляем культуру для Strings.Designer.cs
            Strings.Culture = _currentCulture;

            // Уведомляем об изменении
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        public CultureInfo CurrentCulture => _currentCulture;
    }
}