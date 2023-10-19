using CleanFunctionApp.Domain.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace CleanFunctionApp.Infrastructure;

public static class Injector
{
    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
    }
}