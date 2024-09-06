namespace TruckEase.Exceptions;

using TruckEase.Mediator.Contracts;


public abstract class TruckEaseBaseException : Exception
{
    protected TruckEaseBaseException()
    : base()
    {
    }

    protected TruckEaseBaseException(string message)
         : base(message)
    {
    }

    protected TruckEaseBaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected TruckEaseBaseException(string message, PublishNotification notification)
    : base($"{message} {notification}")
    {
    }
}