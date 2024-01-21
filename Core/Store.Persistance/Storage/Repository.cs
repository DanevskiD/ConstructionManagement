using Microsoft.EntityFrameworkCore;
using Store.Persistance.Context;
using Store.Persistance.Interfaces;

namespace Store.Persistance.Storage
{
    public class Repository<T> : IRepository<T>
        where T : class, IBaseEntity
    {
        public Repository(StoreDbContext databaseContext)
        {
            DbContext = databaseContext;
            DbSet = DbContext.Set<T>();
        }

        public DbSet<T> DbSet { get; }

        protected StoreDbContext DbContext { get; }

        public IQueryable<T> All()
        {
            return DbSet.Where(f => f.DeletedOn == null);
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await All().SingleOrDefaultAsync(f => f.Id == id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task<T> GetByUidAsync(Guid uid)
        {
            return await All().SingleOrDefaultAsync(f => f.Uid == uid);
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }
    }
}
