namespace TruckEase.Mediator.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using TruckEase.Mediator.Contracts;

public interface ITruckEaseEventsPublisher
{ 
   Task PublishAsync(object notification);

    Task PublishAsync<TNotification>(TNotification notification)
        where TNotification : PublishNotification;

    Task PublishAsync<TNotification>(string jobName, TNotification notification)
        where TNotification : PublishNotification;

    Task PublishAsync(object notification, CancellationToken cancellationToken);

    Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken)
        where TNotification : PublishNotification;

    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request);

    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request);

    Task<object?> SendAsync(object request);

    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken);

    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken);

    Task<object?> SendAsync(object request, CancellationToken cancellationToken);
}
