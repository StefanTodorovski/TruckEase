namespace TruckEase.Mediator.Contracts;

using MediatR;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
