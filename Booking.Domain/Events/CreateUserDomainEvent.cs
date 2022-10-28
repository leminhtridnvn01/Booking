using Booking.Domain.Base;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Events
{
    public class CreateUserDomainEvent : BaseDomainEvent
    {
        public CreateUserDomainEvent(UserTest user)
        {
            this.user = user;
        }

        public UserTest user { get; set; }
    }
}
