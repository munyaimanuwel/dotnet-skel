using __NAMESPACE__.Application.Interfaces;
using __NAMESPACE__.Application.Services;

namespace __NAMESPACE__.API.ServiceCollection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPlaceholderService, PlaceholderService>();
        return services;
    }
}
