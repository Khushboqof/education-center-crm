using EducationCenter.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;

namespace TestEducationCenterUoW.Data.Repositories
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal EducationCenterDbContext dbContext;
        internal DbSet<T> dbSet;

        public GenericRepository()
        {
            this.dbContext = new EducationCenterDbContext();
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entityCreated = await dbSet.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return entityCreated.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);

            if (entity is null)
                return false;

            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
            => expression is null ? dbSet : dbSet.Where(expression);


        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
             => dbSet.FirstOrDefaultAsync(expression);


        public async Task<T> UpdateAsync(T entity)
        {
            var entityUpdated = dbSet.Update(entity);

            dbContext.SaveChanges();

            return entityUpdated.Entity;
        }

        public Task SaveAsync()
            => dbContext.SaveChangesAsync();
    }
}
