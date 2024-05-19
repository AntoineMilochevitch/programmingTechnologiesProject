using PTProject.Service;
using PTProject.ViewModels;
using System.Windows;

namespace PTProject.Views
{
    public partial class UserMasterView : Window
    {
        public UserMasterView(UserMasterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
