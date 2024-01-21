using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        DbSet<T> DbSet { get; }

        IQueryable<T> All();

        Task<T> GetByUidAsync(Guid uid);

        Task<T> GetByIdAsync(int id);

        void Insert(T entity);

        void InsertRange(IEnumerable<T> entities);
    }
}
