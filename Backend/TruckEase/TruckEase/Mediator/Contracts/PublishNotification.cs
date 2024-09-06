namespace TruckEase.Mediator.Contracts;

using MediatR;
using System.Text.Json;


public abstract class PublishNotification : INotification
{
    public override string ToString()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        return JsonSerializer.Serialize(this, GetType(), options);
    }
}
