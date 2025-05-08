using RH98.Mediator.Contracts;

namespace RH98.Mediator.UnitTests;

public class MediatorTests(MediatorFixture fixture) : IClassFixture<MediatorFixture>
{
    private readonly IMediator _mediator = fixture.Mediator;

    [Fact]
    public async Task PingHandler_returns_expected_string()
    {
        // Arrange
        var request = new Ping(99);

        // Act
        string result = await _mediator.Send(request);

        // Assert
        Assert.Equal("Pong 99", result);
    }

    public record Ping(
        int Value) : IRequest<string>;

    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult($"Pong {request.Value.ToString()}");
        }
    }
}
