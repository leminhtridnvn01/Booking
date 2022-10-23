using Booking.API;
using Booking.Domain.Models;
using EventBus.Abstractions;
using EventBusRabbitMQ;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables().Build();

configuration.GetSection("AppSettings").Get<AppSettings>(options => options.BindNonPublicProperties = true);

var hcBuilder = builder.Services.AddHealthChecks();

hcBuilder.AddRabbitMQ($"amqp://localhost", name: "rabbitmq", tags: new string[] { "rabbitmqbus" });

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
