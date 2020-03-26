using System;
using AutoMapper;
using JetBrains.Annotations;
using Radilovsoft.Rest.Data.Core.Contract;
using Radilovsoft.Rest.Data.Core.Contract.Provider;
using Radilovsoft.Rest.Infrastructure.Contract;
using Radilovsoft.Rest.Infrastructure.Service;
using Sample.Db.Model.Client;
using Sample.Dto;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Services
{
    public class RoleRoService : BaseRoService<Role, Guid, BaseDto<Guid>, BaseDto<Guid>>, IRoleRoService
    {
        public RoleRoService([NotNull] IRoDataProvider dataProvider,
            [NotNull] IAsyncHelpers asyncHelpers,
            [NotNull] IOrderHelper orderHelper,
            [NotNull] IMapper mapper) : base(dataProvider, asyncHelpers, orderHelper, mapper)
        {
        }
    }
}