﻿using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Bamanna.DouDian.Configuration;
using Bamanna.DouDian.Configuration.Dto;
using Bamanna.DouDian.UiCustomization;
using Bamanna.DouDian.UiCustomization.Dto;

namespace Bamanna.DouDian.Web.UiCustomization.Metronic
{
    public class Theme5UiCustomizer : UiThemeCustomizerBase, IUiCustomizer
    {
        public Theme5UiCustomizer(ISettingManager settingManager)
            : base(settingManager, AppConsts.Theme5)
        {
        }

        public async Task<UiCustomizationSettingsDto> GetUiSettings()
        {
            var settings = new UiCustomizationSettingsDto
            {
                BaseSettings = new ThemeSettingsDto
                {
                    Layout = new ThemeLayoutSettingsDto
                    {
                        LayoutType = await GetSettingValueAsync(AppSettings.UiManagement.LayoutType),
                    },
                    Header = new ThemeHeaderSettingsDto
                    {
                        DesktopFixedHeader = await GetSettingValueAsync<bool>(AppSettings.UiManagement.Header.DesktopFixedHeader),
                        MobileFixedHeader = await GetSettingValueAsync<bool>(AppSettings.UiManagement.Header.MobileFixedHeader),
                        MinimizeDesktopHeaderType = await GetSettingValueAsync(AppSettings.UiManagement.Header.MinimizeType),
                        HeaderMenuArrows = await GetSettingValueAsync<bool>(AppSettings.UiManagement.Header.MenuArrows)
                    }
                }
            };

            settings.BaseSettings.Theme = ThemeName;
            settings.BaseSettings.Menu.Position = "top";
            settings.BaseSettings.Menu.AsideSkin = "dark";
            settings.BaseSettings.Header.HeaderSkin = "dark";
            settings.BaseSettings.Footer.FixedFooter = false;

            settings.IsLeftMenuUsed = false;
            settings.IsTopMenuUsed = true;
            settings.IsTabMenuUsed = false;

            return settings;
        }

        public async Task UpdateUserUiManagementSettingsAsync(UserIdentifier user, ThemeSettingsDto settings)
        {
            await SettingManager.ChangeSettingForUserAsync(user, AppSettings.UiManagement.Theme, ThemeName);

            await ChangeSettingForUserAsync(user, AppSettings.UiManagement.LayoutType, settings.Layout.LayoutType);
            await ChangeSettingForUserAsync(user, AppSettings.UiManagement.Header.DesktopFixedHeader, settings.Header.DesktopFixedHeader.ToString());
            await ChangeSettingForUserAsync(user, AppSettings.UiManagement.Header.MobileFixedHeader, settings.Header.MobileFixedHeader.ToString());
            await ChangeSettingForUserAsync(user, AppSettings.UiManagement.Header.MinimizeType, settings.Header.MinimizeDesktopHeaderType);
            await ChangeSettingForUserAsync(user, AppSettings.UiManagement.Header.MenuArrows, settings.Header.HeaderMenuArrows.ToString());
        }

        public async Task UpdateTenantUiManagementSettingsAsync(int tenantId, ThemeSettingsDto settings)
        {
            await SettingManager.ChangeSettingForTenantAsync(tenantId, AppSettings.UiManagement.Theme, ThemeName);

            await ChangeSettingForTenantAsync(tenantId, AppSettings.UiManagement.LayoutType, settings.Layout.LayoutType);
            await ChangeSettingForTenantAsync(tenantId, AppSettings.UiManagement.Header.DesktopFixedHeader, settings.Header.DesktopFixedHeader.ToString());
            await ChangeSettingForTenantAsync(tenantId, AppSettings.UiManagement.Header.MobileFixedHeader, settings.Header.MobileFixedHeader.ToString());
            await ChangeSettingForTenantAsync(tenantId, AppSettings.UiManagement.Header.MinimizeType, settings.Header.MinimizeDesktopHeaderType);
            await ChangeSettingForTenantAsync(tenantId, AppSettings.UiManagement.Header.MenuArrows, settings.Header.HeaderMenuArrows.ToString());
        }

        public async Task UpdateApplicationUiManagementSettingsAsync(ThemeSettingsDto settings)
        {
            await SettingManager.ChangeSettingForApplicationAsync(AppSettings.UiManagement.Theme, ThemeName);

            await ChangeSettingForApplicationAsync(AppSettings.UiManagement.LayoutType, settings.Layout.LayoutType);
            await ChangeSettingForApplicationAsync(AppSettings.UiManagement.Header.DesktopFixedHeader, settings.Header.DesktopFixedHeader.ToString());
            await ChangeSettingForApplicationAsync(AppSettings.UiManagement.Header.MobileFixedHeader, settings.Header.MobileFixedHeader.ToString());
            await ChangeSettingForApplicationAsync(AppSettings.UiManagement.Header.MinimizeType, settings.Header.MinimizeDesktopHeaderType);
            await ChangeSettingForApplicationAsync(AppSettings.UiManagement.Header.MenuArrows, settings.Header.HeaderMenuArrows.ToString());
        }

        public async Task<ThemeSettingsDto> GetHostUiManagementSettings()
        {
            var theme = await SettingManager.GetSettingValueForApplicationAsync(AppSettings.UiManagement.Theme);

            return new ThemeSettingsDto
            {
                Theme = theme,
                Layout = new ThemeLayoutSettingsDto
                {
                    LayoutType = await GetSettingValueForApplicationAsync(AppSettings.UiManagement.LayoutType),
                },
                Header = new ThemeHeaderSettingsDto
                {
                    DesktopFixedHeader = await GetSettingValueForApplicationAsync<bool>(AppSettings.UiManagement.Header.DesktopFixedHeader),
                    MobileFixedHeader = await GetSettingValueForApplicationAsync<bool>(AppSettings.UiManagement.Header.MobileFixedHeader),
                    MinimizeDesktopHeaderType = await GetSettingValueForApplicationAsync(AppSettings.UiManagement.Header.MinimizeType),
                    HeaderMenuArrows = await GetSettingValueForApplicationAsync<bool>(AppSettings.UiManagement.Header.MenuArrows)
                }
            };
        }

        public async Task<ThemeSettingsDto> GetTenantUiCustomizationSettings(int tenantId)
        {
            var theme = await SettingManager.GetSettingValueForTenantAsync(AppSettings.UiManagement.Theme, tenantId);

            return new ThemeSettingsDto
            {
                Theme = theme,
                Layout = new ThemeLayoutSettingsDto
                {
                    LayoutType = await GetSettingValueForTenantAsync(AppSettings.UiManagement.LayoutType, tenantId),
                },
                Header = new ThemeHeaderSettingsDto
                {
                    DesktopFixedHeader = await GetSettingValueForTenantAsync<bool>(AppSettings.UiManagement.Header.DesktopFixedHeader, tenantId),
                    MobileFixedHeader = await GetSettingValueForTenantAsync<bool>(AppSettings.UiManagement.Header.MobileFixedHeader, tenantId),
                    MinimizeDesktopHeaderType = await GetSettingValueForTenantAsync(AppSettings.UiManagement.Header.MinimizeType, tenantId),
                    HeaderMenuArrows = await GetSettingValueForTenantAsync<bool>(AppSettings.UiManagement.Header.MenuArrows, tenantId)
                }
            };
        }
    }
}