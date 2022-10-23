using Booking.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            
        }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; } 
    }
}
