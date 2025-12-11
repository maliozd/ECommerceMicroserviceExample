using MediatR;

namespace BuildingBlocks.CQRS
{
    // Command Handler that does not return a value
    public interface ICommandHandler<in TCommand> :
                          ICommandHandler<TCommand, Unit>
                    where TCommand : ICommand<Unit>
    {
    }
    // Command Handler that returns a value
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
                    where TCommand : ICommand<TResponse>
                    where TResponse : notnull
    {
    }
}
