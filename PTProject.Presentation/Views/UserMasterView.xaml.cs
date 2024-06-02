// UserMasterView.xaml.cs
using PTProject.Presentation.ViewModels;
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
    }
}
