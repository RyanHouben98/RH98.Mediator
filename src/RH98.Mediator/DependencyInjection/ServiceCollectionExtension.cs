using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RH98.Mediator.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMediator(
        this IServiceCollection services,
        Action<MediatorOptions>? configure = null)
    {
        services.AddTransient<IMediator, Mediator>();

        var options = new MediatorOptions();

        configure?.Invoke(options);

        services.AddMediator(options);

        return services;
    }

    private static void AddMediator(
        this IServiceCollection services,
        MediatorOptions options)
    {
        if (options.Assemblies.Count is 0)
        {
            throw new InvalidOperationException("No assemblies specified.");
        }

        foreach (var assembly in options.Assemblies)
        {
            foreach (var type in assembly.DefinedTypes.Where(t => !t.IsAbstract && !t.IsInterface))
            {
                foreach (var iface in type.ImplementedInterfaces)
                {
                    if (iface.IsGenericType &&
                        iface.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                    {
                        services.TryAddTransient(iface, type);
                    }
                }
            }
        }
    }
}
