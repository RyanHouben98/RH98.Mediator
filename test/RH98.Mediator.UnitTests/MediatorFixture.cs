using Microsoft.Extensions.DependencyInjection;
using RH98.Mediator.DependencyInjection;

namespace RH98.Mediator.UnitTests;

public class MediatorFixture : IDisposable
{
    public IMediator Mediator { get; }

    public MediatorFixture()
    {
        var services = new ServiceCollection();

        services.AddMediator(options =>
            options.AddAssembly(typeof(MediatorFixture).Assembly));

        Mediator = services.BuildServiceProvider()
            .GetRequiredService<IMediator>();    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}
