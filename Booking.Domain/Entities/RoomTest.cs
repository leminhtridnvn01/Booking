using Booking.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class RoomTest : Entity
    {
        public RoomTest()
        {
            this.Users = new HashSet<UserTest>();
        }
        public string Name { get; set; }
        public virtual ICollection<UserTest> Users { get; set; }
    }
}
