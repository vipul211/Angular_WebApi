using Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastucture.Services
{
    public class DataService<T> : IDataService<T> where T : class, IModel
    {
        private readonly DB_Context _Context;

        public DataService(DB_Context context)
        {
            _Context = context;
        }

        public async Task<Guid> Create(T entity)
        {
            await _Context.AddAsync(entity);
            await _Context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task CreateMany(List<T> entities)
        {
            await _Context.AddRangeAsync(entities);
            await _Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _Context.Remove<T>(entity);
            await _Context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _Context.FindAsync<T>(id);
            await Delete(entity);
        }

        public async Task DeleteMany(List<T> entities)
        {
            _Context.RemoveRange(entities);
            await _Context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _Context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            var query = _Context.Set<T>().AsQueryable();

            if (expression != null)
                query = query.Where(expression);

            return query;
        }

        public IQueryable<T> Query()
        {
            return _Context.Set<T>();
        }

        public async Task Update(T entity)
        {
            _Context.Update<T>(entity);
            await _Context.SaveChangesAsync();
        }
    }
}
