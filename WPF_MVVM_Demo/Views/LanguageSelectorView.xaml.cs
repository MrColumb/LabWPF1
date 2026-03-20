using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_Demo.Services;

namespace WPF_MVVM_Demo.Views
{
    public partial class LanguageSelectorView : UserControl
    {
        private bool _isInitialized = false;

        public LanguageSelectorView()
        {
            InitializeComponent();

            // Устанавливаем выбранный язык по умолчанию после загрузки контрола
            this.Loaded += (s, e) =>
            {
                foreach (ComboBoxItem item in LanguageComboBox.Items)
                {
                    if (item.Tag.ToString() == "ru")
                    {
                        LanguageComboBox.SelectedItem = item;
                        break;
                    }
                }
                _isInitialized = true;
            };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Пропускаем обработку при инициализации
            if (!_isInitialized)
                return;

            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedItem is ComboBoxItem selectedItem)
            {
                string languageCode = selectedItem.Tag.ToString();
                LocalizationService.SetLanguage(languageCode);

                // Показываем сообщение только при реальном переключении пользователем
                string message = string.Format(
                    (string)Application.Current.Resources["LanguageChangedMessage"],
                    languageCode == "ru" ? "Русский" : "English"
                );
                MessageBox.Show(message, (string)Application.Current.Resources["MessageBoxTitle"]);
            }
        }
    }
}