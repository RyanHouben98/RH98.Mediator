using RH98.Mediator.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediator(options => options.AddAssembly(typeof(Program).Assembly));

var app = builder.Build();

app.MapControllers();

app.Run();
