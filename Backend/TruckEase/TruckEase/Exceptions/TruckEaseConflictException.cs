namespace TruckEase.Exceptions;


[Serializable]
public class TruckEaseConflictException : TruckEaseBaseException
{
    public TruckEaseConflictException()
        : base()
    {
    }

    public TruckEaseConflictException(string message)
       : base(message)
    {
    }

    public TruckEaseConflictException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
