using System.Windows;


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
    }
}
