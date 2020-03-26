using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Radilovsoft.Rest.Core.Exception;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Radilovsoft.Rest.Infrastructure.Contract;
using Radilovsoft.Rest.Infrastructure.Contract.Dto;
using Sample.Web.Admin.Models;
using Sample.Dto;

namespace Sample.Web.Admin.Controllers.Base
{
    public abstract class BaseRoController<TService, TDb, TKey, TDto, TFullDto> : BaseController
        where TService : IBaseRoService<TDb, TKey, TDto, TFullDto>
        where TDb : class, IEntity<TKey>
        where TKey : IComparable
        where TDto : class
        where TFullDto : class
    {
        private readonly IFilterHelper _filterHelper;
        private readonly TService _roService;

        protected BaseRoController([NotNull] TService roDataService, [NotNull] IFilterHelper filterHelper)
        {
            _roService = roDataService ?? throw new ArgumentNullException(nameof(roDataService));
            _filterHelper = filterHelper ?? throw new ArgumentNullException(nameof(filterHelper));
        }

        protected async Task<IActionResult> GetByFilter(FilterRequest filter)
        {
            Expression<Func<TDto, bool>> expression = null;
            IPageFilter pageFilter = null;
            IOrder[] orders = null;
            if (filter != null)
            {
                if (filter.Filter != null)
                {
                    expression = _filterHelper.ToExpression<TDto>(filter.Filter);
                }

                pageFilter = filter.PageFilter ?? new PageFilter {Page = 1, PageSize = 20};
                orders = filter.Orders?.ToArray();
            }

            var result = await _roService.GetByFilter(pageFilter, expression, orders)
                .ConfigureAwait(false);
            return Ok(result);
        }

        protected async Task<IActionResult> GetById(TKey id)
        {
            try
            {
                var result = await _roService.GetById(id).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }
    }
}