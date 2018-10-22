using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_tmp.ViewModels;
using Infrastucture.Models;
using Infrastucture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_tmp.Controllers
{
    public abstract class RestController<T> : ControllerBase where T: class,IModel
    {
        protected IDataService<T> _dataService;
        private IModelConverter<T, M> Converter<M>() => Activator.CreateInstance<M>() as IModelConverter<T,M>;

        protected IEnumerable<M> GetAll<M>(Func<IQueryable<T>, IQueryable<T>> query = null)
        {
            var converter = Converter<M>();
            var queryResult = _dataService.Query();

            if (query != null)
                queryResult = query(queryResult);

            return queryResult.Select(x => converter.ConvertTo(x));
        }

        protected M Get<M>(Guid id, Func<IQueryable<T>, IQueryable<T>> query = null)
        {
            var converter = Converter<M>();
            var queryResult = _dataService.Query(q => q.Id == id);

            if (query != null)
                queryResult = query(queryResult);
            
            return converter.ConvertTo(queryResult.FirstOrDefault());
        }

        protected async Task<Guid> Create<M>(M model)
        {
            var converter = Converter<M>();
            return await _dataService.Create(converter.ConvertFrom(model));
        }

        protected async Task Update<M>(M model)
        {
            var converter = Converter<M>();
            await _dataService.Update(converter.ConvertFrom(model));
        }

        protected void Delete<M>(Guid id)
        {
            _dataService.Delete(id);
        }
    }
}