using System;
using AutoMapper;
using Radilovsoft.Rest.Data.Core.Contract;
using Radilovsoft.Rest.Data.Core.Contract.Provider;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Service;
using Sample.Db.Model.Client;
using Sample.Dto;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Services
{
    public class RoleRoService : BaseRoService<Role, Guid, BaseDto<Guid>, BaseDto<Guid>>, IRoleRoService
    {
        public RoleRoService(
            IRoDataProvider dataProvider,
            IAsyncHelpers asyncHelpers,
            IOrderHelper orderHelper,
            IMapper mapper) : base(dataProvider, asyncHelpers, orderHelper, mapper)
        {
        }
    }
}