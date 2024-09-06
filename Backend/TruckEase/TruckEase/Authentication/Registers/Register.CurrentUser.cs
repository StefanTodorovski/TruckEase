#nullable disable

namespace TruckEase.Authentication.Registers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TruckEase.Authentication.Implementation;
using TruckEase.Authentication.Interfaces;

public static partial class Register
{
    public static IServiceCollection RegisterCurrentUser(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            IHttpContextAccessor httpContextAccessor = provider.GetService<IHttpContextAccessor>();

            return AuthService.CreateCurrentUserFromClaims(httpContextAccessor.HttpContext).Result;
        });

        return services;
    }
}