using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors;
public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationContext = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(validators
                        .Select(v => v.ValidateAsync(validationContext))
                        .ToList());

        var fails = validationResults
                        .SelectMany(r => r.Errors)
                        .Where(f => f != null)
                        .ToList();

        if (fails.Count != 0)
        {
            throw new ValidationException(fails);
        }

        return await next(cancellationToken);
    }
}
