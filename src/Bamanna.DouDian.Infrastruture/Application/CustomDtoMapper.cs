using Abp.AutoMapper;
using Abp.Configuration.Startup;
using AutoMapper;

namespace Bamanna.DouDian.Infrasturcture.Modules
{
    /// <summary>
    /// �Զ���Mapper������
    /// </summary>
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        /// <summary>
        /// Creates the mappings.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public static void CreateMappings(IAbpStartupConfiguration configuration)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal(IAbpStartupConfiguration configuration)
        {

            configuration.Modules.AbpAutoMapper().Configurators.Add(cfg => {
                //Add mappings. Example:
                //cfg.CreateMap<Authorization.Users.User, Authorization.Users.Dto.UserEditDto>()
                //    .ForMember(dto => dto.Password, options => options.Ignore())
                //    .ReverseMap()
                //    .ForMember(user => user.Password, options => options.Ignore());
            });
        }
    }
}