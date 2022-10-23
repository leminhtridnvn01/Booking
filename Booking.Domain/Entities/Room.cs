using Booking.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Room : Entity
    {
        public Room()
        {
            this.Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
