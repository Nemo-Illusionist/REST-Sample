using System;
using Radilovsoft.Rest.Infrastructure.Contract;
using Sample.Db.Model.App;
using Sample.Dto.Test;

namespace Sample.Infrastructure.Contracts
{
    public interface ITestService : IBaseCrudService<Test, Guid, TestResponse, TestResponse, TestRequest>
    {
    }
}