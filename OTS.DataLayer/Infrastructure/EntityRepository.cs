using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OTS.DataLayer.Infrastructure
{
    public class EntityRepository<TEntityInterface> : IEntityRepository<TEntityInterface> where TEntityInterface : class
    {
        private readonly OtsDbContext _context;

        public EntityRepository(OtsDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> GetTableInternal<TEntity>() where TEntity : class, TEntityInterface
        {
            var tableInternal = _context.Set<TEntity>();
            return tableInternal;
        }

        public IQueryable<TEntity> GetTable<TEntity>() where TEntity : class, TEntityInterface
        {
            return GetTableInternal<TEntity>();
        }

        public void InsertOnSave<TEntity>(TEntity entity) where TEntity : class, TEntityInterface
        {
            GetTableInternal<TEntity>()
                .Add(entity);
        }

        public void InsertRangeOnSave<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, TEntityInterface
        {
            GetTableInternal<TEntity>()
                .AddRange(entities);
        }

        public void DeleteOnSave<TEntity>(TEntity entity) where TEntity : class, TEntityInterface
        {
            GetTableInternal<TEntity>()
                .Remove(entity);
        }

        public void DeleteRangeOnSave<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, TEntityInterface
        {
            GetTableInternal<TEntity>()
                .RemoveRange(entities);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
