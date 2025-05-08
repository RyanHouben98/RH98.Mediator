using RH98.Mediator.Contracts;

namespace RH98.Mediator;

/// <summary>
/// Defines the mediator pattern functions.
/// </summary>
public interface IMediator
{
    /// <summary>
    /// The mediator send pattern. Sends a request to a request handler without a result.
    /// </summary>
    /// <param name="request">The request object.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns></returns>
    Task Send(IRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// The mediator send pattern. Sends a request to a request handler with a result.
    /// </summary>
    /// <param name="request">The request object.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <typeparam name="TResult">The result object.</typeparam>
    /// <returns></returns>
    Task<TResult> Send<TResult>(IRequest<TResult> request, CancellationToken cancellationToken = default);
}
