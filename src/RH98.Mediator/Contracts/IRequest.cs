namespace RH98.Mediator.Contracts;

/// <summary>
/// Marker request interface without a result.
/// </summary>
public interface IRequest { }

/// <summary>
/// Marker request interface with a result.
/// </summary>
/// <typeparam name="TResult">The result that the request returns.</typeparam>
public interface IRequest<out TResult> { }
