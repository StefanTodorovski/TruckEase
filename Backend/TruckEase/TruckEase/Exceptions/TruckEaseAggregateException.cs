namespace TruckEase.Exceptions;

public class TruckEaseAggregateException : AggregateException
{
    public TruckEaseAggregateException()
        : base()
    {
    }

    public TruckEaseAggregateException(string message)
        : base(message)
    {
    }

    public TruckEaseAggregateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public TruckEaseAggregateException(IEnumerable<Exception> innerExceptions)
        : base(innerExceptions)
    {
    }
}