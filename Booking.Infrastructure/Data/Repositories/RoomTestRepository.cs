using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data.Repositories
{
    public class RoomTestRepository : GenericRepository<RoomTest>, IRoomTestRepository
    {
        public RoomTestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
