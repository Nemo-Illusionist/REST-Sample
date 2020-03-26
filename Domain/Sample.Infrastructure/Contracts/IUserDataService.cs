using System;
using Radilovsoft.Rest.Infrastructure.Contract;
using Sample.Db.Model.Client;
using Sample.Dto.Users;

namespace Sample.Infrastructure.Contracts
{
    public interface IUserDataService : IBaseCrudService<UserData, Guid, UserDataResponse, UserDataFullResponse, UserDataRequest>
    {
    }
}