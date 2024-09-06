namespace TruckEase.Exceptions;

using System;

[Serializable]
public class TruckEaseForbiddenException : TruckEaseBaseException
{
    public TruckEaseForbiddenException()
        : base()
    {
    }

    public TruckEaseForbiddenException(string message)
        : base(message)
    {
    }

    public TruckEaseForbiddenException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}
