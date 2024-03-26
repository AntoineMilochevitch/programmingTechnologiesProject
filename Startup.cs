using System;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICatalog, Catalog>();
        services.AddScoped<IUsers, Users>();
    }
}
