using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Configuration.Host.Dto;
using Bamanna.DouDian.Editions.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}