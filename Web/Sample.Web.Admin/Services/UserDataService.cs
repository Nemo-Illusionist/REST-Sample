using System;
using AutoMapper;
using Radilovsoft.Rest.Data.Core.Contract;
using Radilovsoft.Rest.Data.Core.Contract.Provider;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Service;
using Sample.Db.Model.Client;
using Sample.Dto.Users;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin.Services
{
    public class UserDataService : BaseCrudService<UserData, Guid, UserDataResponse, UserDataFullResponse, UserDataRequest>, IUserDataService
    {
        public UserDataService(IDataProvider dataProvider, IAsyncHelpers asyncHelpers, IOrderHelper orderHelper,
            IMapper mapper)
            : base(dataProvider, asyncHelpers, orderHelper, mapper)
        {
        }
    }
}