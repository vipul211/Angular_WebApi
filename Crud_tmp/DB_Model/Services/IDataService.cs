using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);

        Task<Guid> Create(T entity);
        Task Update(T entity);

        Task Delete(T entity);
        Task Delete(Guid id);

        Task CreateMany(List<T> entities);
        Task DeleteMany(List<T> entities);

        IQueryable<T> Query(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
    }
}
