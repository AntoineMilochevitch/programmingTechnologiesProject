using PTProject.Data;
using PTProject.Presentation.ViewModels;
using PTProject.Presentation.Views;
using PTProject.Service;
using PTProject.ViewModels;
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

            // Create connection to db
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            PTProjectDataContext context = new PTProjectDataContext(connectionString);

            // Create an instance of your ViewModel
            UserMasterViewModel viewModelUser = new UserMasterViewModel(new UserService(context));
            GoodMasterViewModel viewModelGood = new GoodMasterViewModel(new GoodService(context),new ProcessStateService(context));

            // Create an instance of your View, passing the ViewModel to its constructor
            UserMasterView viewUser = new UserMasterView(viewModelUser);
            GoodMasterView viewGood = new Views.GoodMasterView(viewModelGood);

            // Show the View
            viewUser.Show();
            viewGood.Show();
        }

    }
}
