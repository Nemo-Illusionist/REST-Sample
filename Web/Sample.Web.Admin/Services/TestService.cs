using System;
using AutoMapper;
using Radilovsoft.Rest.Data.Core.Contract;
using Radilovsoft.Rest.Data.Core.Contract.Provider;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Service;
using Sample.Db.Model.App;
using Sample.Dto.Test;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Services
{
    public class TestService : BaseCrudService<Test, Guid, TestResponse, TestResponse, TestRequest>, ITestService
    {
        public TestService(IDataProvider dataProvider, IAsyncHelpers asyncHelpers, IOrderHelper orderHelper,
            IMapper mapper)
            : base(dataProvider, asyncHelpers, orderHelper, mapper)
        {
        }
    }
}