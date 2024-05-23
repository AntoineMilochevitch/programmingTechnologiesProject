using PTProject.Presentation.Views;
using PTProject.Presentation.ViewModels;
using PTProject.Service;
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

            // Create service factory
            IServiceFactory serviceFactory = new ServiceFactory(connectionString);

            // Create services
            IUserService userService = serviceFactory.CreateUserService();
            IGoodService goodService = serviceFactory.CreateGoodService();
            IProcessStateService processStateService = serviceFactory.CreateProcessStateService();

            // Create an instance of your ViewModel
            UserMasterViewModel viewModelUser = new UserMasterViewModel(userService);
            GoodMasterViewModel viewModelGood = new GoodMasterViewModel(goodService, processStateService);

            // Create an instance of your View, passing the ViewModel to its constructor
            UserMasterView viewUser = new UserMasterView(viewModelUser);
            GoodMasterView viewGood = new GoodMasterView(viewModelGood);

            // Show the View
            viewUser.Show();
            viewGood.Show();
        }
    }
}
