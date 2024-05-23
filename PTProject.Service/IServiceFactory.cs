
namespace PTProject.Service
{
    public interface IServiceFactory
    {
        IUserService CreateUserService();
        IGoodService CreateGoodService();
        IProcessStateService CreateProcessStateService();
    }
}

