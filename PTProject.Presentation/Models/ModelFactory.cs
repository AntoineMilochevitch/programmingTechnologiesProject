using PTProject.Service;

namespace PTProject.Presentation.Models
{
    public class ModelFactory
    {
        private readonly IServiceFactory _serviceFactory;

        public ModelFactory(string connectionString)
        {
            _serviceFactory = new ServiceFactory(connectionString);
        }

        public UserModel CreateUserModel()
        {
            IUserService userService = _serviceFactory.CreateUserService();
            return new UserModel(userService);
        }

        public GoodModel CreateGoodModel()
        {
            IGoodService goodService = _serviceFactory.CreateGoodService();
            return new GoodModel(goodService);
        }
    }
}
