using PTProject.Presentation.ViewModels;
using PTProject.Service;
using PTProject.ViewModels;
using System.Configuration;
using System.Windows;

namespace PTProject.Presentation.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create an instance of your ViewModel
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            UserMasterViewModel viewModelUser = new UserMasterViewModel(new UserService(connectionString));
            GoodMasterViewModel viewModelGood = new GoodMasterViewModel(new GoodService(connectionString));

            // Create an instance of your View, passing the ViewModel to its constructor
            

            // Create an instance of your View, passing the ViewModel to its constructor
            UserMasterView viewUser = new UserMasterView(viewModelUser);
            GoodMasterView viewGood = new GoodMasterView(viewModelGood);

            // Show the View
            viewUser.Show();
            viewGood.Show();
        }
    }
}
