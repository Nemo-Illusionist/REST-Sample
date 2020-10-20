using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Dto;
using Sample.Web.Admin.Controllers.Base;
using Sample.Web.Admin.Models;
using Sample.Db.Model.Client;
using Sample.Dto;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Controllers.V1
{
    public class RoleController : BaseRoController<IRoleRoService, Role, Guid, BaseDto<Guid>, BaseDto<Guid>>
    {
        public RoleController(IRoleRoService crudService, IFilterHelper filterHelper)
            : base(crudService, filterHelper)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<BaseDto<Guid>>), 200)]
        public Task<IActionResult> Get([FromBody] FilterRequest filter)
        {
            return GetByFilter(filter);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseDto<Guid>), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public Task<IActionResult> Get(Guid id)
        {
            return GetById(id);
        }
    }
}