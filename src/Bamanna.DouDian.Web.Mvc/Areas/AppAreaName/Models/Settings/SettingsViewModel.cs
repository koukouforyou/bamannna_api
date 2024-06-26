﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Configuration.Tenants.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}