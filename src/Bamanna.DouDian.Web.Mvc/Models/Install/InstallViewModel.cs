using System.Collections.Generic;
using Abp.Localization;
using Bamanna.DouDian.Install.Dto;

namespace Bamanna.DouDian.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
