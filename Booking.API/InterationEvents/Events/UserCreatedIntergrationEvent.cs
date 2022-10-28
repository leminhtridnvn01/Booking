using EventBus.Events;

namespace Booking.API.InterationEvents.Events
{
    public class UserCreatedIntergrationEvent : IntegrationEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserCreatedIntergrationEvent(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
