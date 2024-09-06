namespace TruckEase.Mediator.Contracts;

using MediatR;

public interface IPublishNotificationHandler<T> : INotificationHandler<T>
    where T : INotification
{
}