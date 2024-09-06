namespace TruckEase.Exceptions;

using TruckEase.Mediator.Contracts;

public class TruckEaseValidationException : TruckEaseBaseException
{
    public TruckEaseValidationException()
    : base()
    {
    }

    public TruckEaseValidationException(string message)
        : base(message)
    {
    }

    public TruckEaseValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public TruckEaseValidationException(string message, PublishNotification notification)
        : base(message, notification)
    {
    }
}
