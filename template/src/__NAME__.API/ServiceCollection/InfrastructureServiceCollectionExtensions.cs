using __NAMESPACE__.Domain.Interfaces;
using __NAMESPACE__.Infrastructure.Persistence;

namespace __NAMESPACE__.API.ServiceCollection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();
        return services;
    }
}
