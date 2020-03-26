using System;
using AutoMapper;
using NUnit.Framework;
using Sample.Infrastructure.Profiles;
using Sample.Web.Admin.Profiles;

namespace Sample.Tests.Unit
{
    public class MapperTests
    {
        [TestCase(typeof(TesterDtoMappingProfile))]
        [TestCase(typeof(TesterAdminMappingProfile))]
        public void MapperTest(Type profileType)
        {
            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(profileType));
            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}