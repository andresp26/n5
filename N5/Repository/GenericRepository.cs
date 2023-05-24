using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
     public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected N5DbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(N5DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();

        }
        public virtual Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }


        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }


        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
