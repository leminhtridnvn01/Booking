using EventBus.Abstractions;
using EventBus.Events;
using System.Data.Common;

namespace API.IntegrationEvents
{
    public class BookingIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<BookingIntegrationEventService> _logger;
        private volatile bool disposedValue;
        public BookingIntegrationEventService(ILogger<BookingIntegrationEventService> logger,
            IEventBus eventBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            try
            {

                _eventBus.Publish(evt);
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
