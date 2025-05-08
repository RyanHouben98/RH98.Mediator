using RH98.Mediator.Contracts;

namespace RH98.Mediator;

public sealed class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task Send(IRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(request));

        var handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
        dynamic handler = _serviceProvider.GetService(handlerType)!;

        if (handler is null)
            throw new InvalidOperationException($"Handler of type {handlerType} was not found.");

        return handler.Handle((dynamic)request, cancellationToken);
    }

    public Task<TResult> Send<TResult>(IRequest<TResult> request, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(request));

        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResult));
        dynamic handler = _serviceProvider.GetService(handlerType)!;

        if (handler is null)
            throw new InvalidOperationException($"Handler of type {handlerType} was not found.");

        return handler.Handle((dynamic)request, cancellationToken);
    }
}
