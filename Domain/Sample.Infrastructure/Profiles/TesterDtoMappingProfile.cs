using System;
using AutoMapper;
using Sample.Db.Model.App;
using Sample.Db.Model.Client;
using Sample.Dto;
using Sample.Dto.Test;
using Sample.Dto.Users;

namespace Sample.Infrastructure.Profiles
{
    public class TesterDtoMappingProfile : Profile
    {
        public TesterDtoMappingProfile()
        {
            CreateMap<Role, BaseDto<Guid>>();

            CreateMap<Test, TestResponse>()
                .ForMember(x => x.AuthorName,
                    x => x.MapFrom(y => y.Author.UserData.Name + " " + y.Author.UserData.LastName));
            CreateMap<TestRequest, Test>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.Author, x => x.Ignore())
                .ForMember(x => x.TestTopics, x => x.Ignore())
                .ForMember(x => x.CreatedUtc, x => x.Ignore())
                .ForMember(x => x.DeletedUtc, x => x.Ignore())
                .ForMember(x => x.UpdatedUtc, x => x.Ignore());

            CreateMap<UserDataRequest, UserData>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.User, x => x.Ignore())
                .ForMember(x => x.UpdatedUtc, x => x.Ignore());
            CreateMap<UserData, UserDataResponse>();
            CreateMap<UserData, UserDataFullResponse>()
                .IncludeBase<UserData, UserDataResponse>()
                .ForMember(x => x.CreatedUtc, x => x.MapFrom(y => y.User.CreatedUtc));
        }
    }
}