using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PTProject.ViewModels;

namespace PTProject.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour CollectionMasterView.xaml
    /// </summary>
    public partial class CollectionMasterView : Window
    {
        public CollectionMasterView(PTProject.Presentation.ViewModels.GoodMasterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
