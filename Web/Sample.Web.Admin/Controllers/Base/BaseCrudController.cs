using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radilovsoft.Rest.Core.Exceptions;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Radilovsoft.Rest.Infrastructure.Contract;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;

namespace Sample.Web.Admin.Controllers.Base
{
    public abstract class BaseCrudController<TService, TDb, TKey, TDto, TFullDto, TRequest>
        : BaseRoController<TService, TDb, TKey, TDto, TFullDto>
        where TService : IBaseCrudService<TDb, TKey, TDto, TFullDto, TRequest>
        where TDb : class, IEntity<TKey>
        where TKey : IComparable
        where TDto : class
        where TFullDto : class
        where TRequest : class
    {
        private readonly TService _crudService;

        protected BaseCrudController(TService crudDataService, IFilterHelper filterHelper)
            : base(crudDataService, filterHelper)
        {
            _crudService = crudDataService ?? throw new ArgumentNullException(nameof(crudDataService));
        }


        protected async Task<IActionResult> AddEntity(TRequest item)
        {
            var id = await _crudService.PostAsync(item).ConfigureAwait(false);
            var result = await _crudService.GetByIdAsync(id).ConfigureAwait(false);
            
            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(GetById), new {id}, result);
        }

        protected async Task<IActionResult> UpdateEntity(TKey id, TRequest item)
        {
            try
            {
                await _crudService.PutAsync(id, item).ConfigureAwait(false);
                return NoContent();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }

        protected async Task<IActionResult> DeleteEntity(TKey id)
        {
            try
            {
                await _crudService.DeleteAsync(id).ConfigureAwait(false);
                return NoContent();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }
    }
}