using Aurum.Application;
using Aurum.Application.Services;

namespace EFCoreTest.Configurations;
/// <summary>
/// This class is used to register services and repositories in the application.
/// Since the amount of services and repositories is large, it is better to separate them into a separate class.
/// <br/>
/// <br/>
/// Cool pattern I picked up from the internet.
/// </summary>
public static class ServiceRepositoryRegistration
{
    public static void RegisterServicesAndRepositories(this IServiceCollection services)
    {
        //services
        services.AddScoped<PondanService>();
    }
}