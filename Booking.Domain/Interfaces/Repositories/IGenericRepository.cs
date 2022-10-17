﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task<T?> FindAsync(params object[] keyValues);

        void Update(T entity);

        Task Remove(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
