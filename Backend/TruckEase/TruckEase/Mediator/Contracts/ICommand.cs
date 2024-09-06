namespace TruckEase.Mediator.Contracts;

using MediatR;

public interface ICommand<out TResult> : IRequest<TResult>
{
}