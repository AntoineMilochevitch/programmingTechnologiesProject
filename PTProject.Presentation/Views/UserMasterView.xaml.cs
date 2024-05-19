using PTProject.ViewModels;
using System.Windows;

namespace PTProject.Presentation.Views
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
