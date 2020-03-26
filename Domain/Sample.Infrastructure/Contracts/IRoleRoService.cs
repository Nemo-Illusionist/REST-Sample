using System;
using Radilovsoft.Rest.Infrastructure.Contract;
using Sample.Db.Model.Client;
using Sample.Dto;

namespace Sample.Infrastructure.Contracts
{
    public interface IRoleRoService : IBaseRoService<Role, Guid, BaseDto<Guid>>
    {
    }
}