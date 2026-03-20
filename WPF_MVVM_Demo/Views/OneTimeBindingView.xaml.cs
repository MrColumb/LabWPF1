using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_Demo.ViewModels;

namespace WPF_MVVM_Demo.Views
{
    public partial class OneTimeBindingView : UserControl
    {
        public OneTimeBindingView()
        {
            InitializeComponent();
        }

        private void UpdateTimeButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneTimeBindingViewModel viewModel)
            {
                viewModel.UpdateTime();
            }
        }

        private void ChangeNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is OneTimeBindingViewModel viewModel)
            {
                viewModel.Person.FirstName = NewNameTextBox.Text;
                viewModel.OnPropertyChanged(nameof(viewModel.Person));
            }
        }
    }
}