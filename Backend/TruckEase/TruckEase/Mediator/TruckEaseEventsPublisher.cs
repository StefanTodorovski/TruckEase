namespace TruckEase.Mediator;

using MediatR;
using TruckEase.Exceptions;
using TruckEase.Mediator.Contracts;
using TruckEase.Mediator.Interfaces;


public class TruckEaseEventsPublisher : ITruckEaseEventsPublisher
{
    private readonly TruckEaseMediator truckEaseMediator;

    public TruckEaseEventsPublisher(ServiceFactory serviceFactory)
    {
        truckEaseMediator = new TruckEaseMediator(serviceFactory, SyncContinueOnExceptionAsync);
    }

    public async Task PublishAsync(object notification)
    {
        await PublishAsync(notification, default);
    }

    public async Task PublishAsync<TNotification>(TNotification notification)
        where TNotification : PublishNotification
    {
        await PublishAsync(notification, default);
    }

    public async Task PublishAsync<TNotification>(string jobName, TNotification notification)
        where TNotification : PublishNotification
    {
        await PublishAsync(notification, default);
    }

    public async Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken)
        where TNotification : PublishNotification
    {
        await truckEaseMediator.Publish(notification, cancellationToken);
    }

    public async Task PublishAsync(object notification, CancellationToken cancellationToken)
    {
        await truckEaseMediator.Publish(notification, cancellationToken);
    }

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request)
    {
        return await SendAsync(request, default);
    }

    public async Task<object?> SendAsync(object request)
    {
        return await SendAsync(request, default);
    }

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken)
    {
        return await truckEaseMediator.Send(request, cancellationToken);
    }

    public async Task<object?> SendAsync(object request, CancellationToken cancellationToken)
    {
        return await truckEaseMediator.Send(request, cancellationToken);
    }

    public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request)
    {
        return await SendAsync(request, default);
    }

    public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken)
    {
        return await truckEaseMediator.Send(request, cancellationToken);
    }

    private async Task SyncContinueOnExceptionAsync(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken)
    {
        List<Exception> exceptions = new List<Exception>();

        foreach (Func<INotification, CancellationToken, Task> handler in handlers)
        {
            try
            {
                await handler(notification, cancellationToken);
            }
            catch (AggregateException ex)
            {
                exceptions.AddRange(ex.Flatten().InnerExceptions);
            }
            catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
            {
                exceptions.Add(ex);
            }
        }

        if (exceptions.Any())
        {
            throw new TruckEaseAggregateException(exceptions);
        }
    }
}
