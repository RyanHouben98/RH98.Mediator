using RH98.Mediator.DependencyInjection;

namespace RH98.Mediator.UnitTests.DependencyInjectionTests;

public class MediatorOptionsTests
{
    [Fact]
    public void AddAssembly_Success_ShouldAddTheAssembly()
    {
        // Arrange
        var options = new MediatorOptions();
        var assembly = typeof(MediatorOptionsTests).Assembly;

        // Act
        options.AddAssembly(assembly);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.Single(options.Assemblies);
            Assert.Equal(assembly, options.Assemblies[0]);
        });
    }
}
