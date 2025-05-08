using System.Reflection;

namespace RH98.Mediator.DependencyInjection;

public sealed class MediatorOptions
{
    private readonly List<Assembly> _assemblies = [];

    public IReadOnlyList<Assembly> Assemblies => _assemblies;

    public MediatorOptions AddAssembly(Assembly assembly)
    {
        _assemblies.Add(assembly);
        return this;
    }
}
