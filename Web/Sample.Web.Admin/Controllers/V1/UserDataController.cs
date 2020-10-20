using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Dto;
using Sample.Web.Admin.Controllers.Base;
using Sample.Web.Admin.Models;
using Sample.Db.Model.Client;
using Sample.Dto;
using Sample.Dto.Users;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Controllers.V1
{
    public class UserDataController :
        BaseCrudController<IUserDataService, UserData, Guid, UserDataResponse, UserDataFullResponse, UserDataRequest>
    {
        public UserDataController(IUserDataService crudDataService, IFilterHelper filterHelper)
            : base(crudDataService, filterHelper)
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
        
        [HttpPost("{id}")]
        [ProducesResponseType(typeof(UserDataFullResponse), 200)]
        public Task<IActionResult> Update(Guid id, UserDataRequest request)
        {
            return UpdateEntity(id, request);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public Task<IActionResult> Delete(Guid id)
        {
            return DeleteEntity(id);
        }
    }
}