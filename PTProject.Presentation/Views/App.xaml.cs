using PTProject.Presentation.ViewModels;
using System.Configuration;
using System.Windows;

namespace PTProject.Presentation.Views
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

            ViewModelFactory viewModelFactory = new ViewModelFactory(connectionString);

            UserMasterViewModel userMasterViewModel = viewModelFactory.CreateUserMasterViewModel();
            GoodMasterViewModel goodMasterViewModel = viewModelFactory.CreateGoodMasterViewModel();

            UserMasterView userMasterView = new UserMasterView(userMasterViewModel);
            GoodMasterView goodMasterView = new GoodMasterView(goodMasterViewModel);

            userMasterView.Show();
            goodMasterView.Show();
        }
    }
}
