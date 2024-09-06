#nullable disable
using TruckEase.Interfaces.DataProtection;
using TruckEase.Storage;

namespace TruckEase;

public static class ServiceManager
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static T CreateServiceScope<T>(IApplicationBuilder app)
    {
        IServiceScopeFactory serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
        using IServiceScope scope = serviceScopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }
}
