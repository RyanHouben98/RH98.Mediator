using RH98.Mediator.Contracts;

namespace RH98.Mediator.Sample.WebApi.Features;

public sealed record ListUsersQuery() : IRequest<List<string>>;

public sealed class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, List<string>>
{
    public Task<List<string>> Handle(ListUsersQuery request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new List<string>{"John Doe", "Jane Doe"});
    }
}
