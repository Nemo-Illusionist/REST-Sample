using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Dto;
using Sample.Web.Admin.Controllers.Base;
using Sample.Web.Admin.Models;
using Sample.Db.Model.App;
using Sample.Dto;
using Sample.Dto.Test;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Controllers.V1
{
    public class TestController :
        BaseCrudController<ITestService, Test, Guid, TestResponse, TestResponse, TestRequest>
    {
        public TestController(ITestService crudDataService, IFilterHelper filterHelper)
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

        [HttpPut]
        [ProducesResponseType(typeof(TestResponse), 201)]
        public Task<IActionResult> Add(TestRequest request)
        {
            return AddEntity(request);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(typeof(TestResponse), 200)]
        public Task<IActionResult> Update(Guid id, TestRequest request)
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