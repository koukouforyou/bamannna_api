using AutoMapper;
using Bamanna.DouDian.Authorization.Users;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Startup
{
    public static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserDto>()
                .ForMember(dto => dto.Roles, options => options.Ignore())
                .ForMember(dto => dto.OrganizationUnits, options => options.Ignore());
        }
    }
}