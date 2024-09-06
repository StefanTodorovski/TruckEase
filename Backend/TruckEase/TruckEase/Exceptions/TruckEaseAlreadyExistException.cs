namespace TruckEase.Exceptions;

using TruckEase.Mediator.Contracts;

public class TruckEaseAlreadyExistException : TruckEaseBaseException
{
    public TruckEaseAlreadyExistException()
    : base()
    {
    }

    public TruckEaseAlreadyExistException(string message)
        : base(message)
    {
    }

    public TruckEaseAlreadyExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public TruckEaseAlreadyExistException(string message, PublishNotification notification)
        : base(message, notification)
    {
    }
}
