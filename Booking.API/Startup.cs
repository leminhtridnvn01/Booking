using Booking.API.Extensions;
using Booking.API.InterationEvents.Events;
using Booking.Domain.Interfaces.Repositories;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.Data.Repositories;
using EventBus;
using EventBus.Abstractions;
using EventBusRabbitMQ;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Booking.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();

            services.AddDbContext(Configuration);
            services.AddGenericRepositories();
            services.AddUnitOfWork();

            services.RegisterRabbitMQ(Configuration);
            services.RegisterEventBus();
            services.RegisterMediator();
        }

        public void ConfigureEventBus(WebApplication app)
        {
            var eventBus = app.Services.GetRequiredService<IEventBus>();

            eventBus.Subscribe<UserCreatedIntergrationEvent, IIntegrationEventHandler<UserCreatedIntergrationEvent>>();
            //eventBus.Subscribe<UserUpdatedIntergrationEvent, IIntegrationEventHandler<UserUpdatedIntergrationEvent>>();
        }
    }
}
