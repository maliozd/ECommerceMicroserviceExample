using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit> //unit is void type, when you dont need to return anything
    {

    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
