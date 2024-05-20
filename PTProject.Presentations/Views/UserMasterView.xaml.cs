// UserMasterView.xaml.cs
using PTProject.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace PTProject.Presentation.Views
{
    public partial class UserMasterView : Window
    {
        public UserMasterView(UserMasterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as UserMasterViewModel;
            if (viewModel != null)
            {
                viewModel.SelectUserCommand.Execute(null);
            }
        }
    }
}
