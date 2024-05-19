using System.Windows;
using System.Windows.Controls;


namespace PTProject.Presentation.Views
{
    /// <summary>
    /// Interaction logic for GoodMasterView.xaml
    /// </summary>
    public partial class GoodMasterView : Window
    {
        public GoodMasterView(GoodMasterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as GoodMasterViewModel;
            if (viewModel != null)
            {
                viewModel.ShowGoodDetailsCommand.Execute(null);
            }
        }
    }
}
