using Booking.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class UserTest : Entity
    {
        public UserTest()
        {
            
        }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public virtual RoomTest Room { get; set; } 
    }
}
