namespace TruckEase.Registers;

using TruckEase.Mediator;
using TruckEase.Mediator.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TruckEase.Interfaces.DataProtection;
using TruckEase.Storage;

public static partial class Register
{
    public static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program));
        services.AddScoped<ITruckEaseEventsPublisher, TruckEaseEventsPublisher>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}