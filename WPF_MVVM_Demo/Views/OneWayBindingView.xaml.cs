using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_Demo.ViewModels;

namespace WPF_MVVM_Demo.Views
{
    public partial class OneWayBindingView : UserControl
    {
        public OneWayBindingView()
        {
            InitializeComponent();
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneWayBindingViewModel viewModel)
            {
                viewModel.IncrementCounter();
            }
        }

        private void ChangeFirstNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneWayBindingViewModel viewModel)
            {
                viewModel.Person.FirstName = "Новое имя";
                viewModel.OnPropertyChanged(nameof(viewModel.Person));
            }
        }

        private void IncreaseAgeButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneWayBindingViewModel viewModel)
            {
                viewModel.Person.Age++;
                viewModel.OnPropertyChanged(nameof(viewModel.Person));
            }
        }
    }
}