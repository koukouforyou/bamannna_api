using Abp.Localization;
using Abp.Web.Models.AbpUserConfiguration;
using JetBrains.Annotations;
using Bamanna.DouDian.Sessions.Dto;

namespace Bamanna.DouDian.DouDianClient
{
    public interface IApplicationContext
    {
        [CanBeNull]
        TenantInformation CurrentTenant { get; }

        AbpUserConfigurationDto Configuration { get; set; }

        GetCurrentLoginInformationsOutput LoginInfo { get; }

        void ClearLoginInfo();

        void SetLoginInfo(GetCurrentLoginInformationsOutput loginInfo);

        void SetAsHost();

        void SetAsTenant(string tenancyName, int tenantId);

        LanguageInfo CurrentLanguage { get; set; }

        void Load(TenantInformation currentTenant, GetCurrentLoginInformationsOutput loginInfo);
    }
}