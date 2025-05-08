using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using RH98.Mediator.Contracts;
using RH98.Mediator.DependencyInjection;

namespace RH98.Mediator.Benchmarks;

public class MediatorBenchmark
{
    private IMediator _mediator;
    private readonly PingRequest _request = new ();

    [GlobalSetup]
    public void Setup()
    {
        var services = new ServiceCollection();

        services.AddMediator(options =>
        {
            options.AddAssembly(typeof(PingRequestHandler).Assembly);
        });

        services.AddTransient<IRequestHandler<PingRequest>, PingRequestHandler>();

        var provider = services.BuildServiceProvider();

        _mediator = provider.GetRequiredService<IMediator>();
    }

    [Benchmark]
    public Task SendingRequests()
    {
        return _mediator.Send(_request);
    }
}

public record PingRequest() : IRequest;

public class PingRequestHandler : IRequestHandler<PingRequest>
{
    public Task Handle(PingRequest request, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
