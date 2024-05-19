using PTProject.Service;
using PTProject.ViewModels;
using PTProject.Views;
using System.Configuration;
using System.Windows;

namespace PTProject.Presentation
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
            UserMasterViewModel viewModel = new UserMasterViewModel(new UserService(connectionString));

            // Create an instance of your View, passing the ViewModel to its constructor
            UserMasterView view = new UserMasterView(viewModel);

            // Show the View
            view.Show();
        }
    }
}
