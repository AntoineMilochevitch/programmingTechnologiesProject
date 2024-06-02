using PTProject.Presentation.Models;

namespace PTProject.Presentation.ViewModels
{
    public class ViewModelFactory
    {
        private readonly ModelFactory _modelFactory;

        public ViewModelFactory(string connectionString)
        {
            _modelFactory = new ModelFactory(connectionString);
        }

        public UserMasterViewModel CreateUserMasterViewModel()
        {
            UserModel userModel = _modelFactory.CreateUserModel();
            return new UserMasterViewModel(userModel);
        }

        public GoodMasterViewModel CreateGoodMasterViewModel()
        {
            GoodModel goodModel = _modelFactory.CreateGoodModel();
            return new GoodMasterViewModel(goodModel);
        }
    }
}
