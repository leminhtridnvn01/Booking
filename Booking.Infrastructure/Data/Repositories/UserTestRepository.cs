using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data.Repositories
{
    public class UserTestRepository : GenericRepository<UserTest>, IUserTestRepository
    {
        public UserTestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<UserTest> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
