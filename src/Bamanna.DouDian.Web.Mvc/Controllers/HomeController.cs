﻿using System;
using System.Threading.Tasks;
using Abp;
using Abp.Localization;
using Abp.Notifications;
using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Identity;
using Bamanna.DouDian.Notifications;

namespace Bamanna.DouDian.Web.Controllers
{
    public class HomeController : DouDianControllerBase
    {
        private readonly SignInManager _signInManager;
        private readonly INotificationPublisher _notificationPublisher;

        public HomeController(SignInManager signInManager, INotificationPublisher notificationPublisher)
        {
            _signInManager = signInManager;
            _notificationPublisher = notificationPublisher;
        }

        public async Task<IActionResult> Index(string redirect = "", bool forceNewRegistration = false)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                await SchedulerNewInvoiceForecastCreatedAsync(null, 1);
                uow.Complete();
            }

            using (var uow = UnitOfWorkManager.Begin())
            {
                await SchedulerNewInvoiceForecastCreatedAsync(null, 2);
                uow.Complete();
            }


            if (forceNewRegistration)
            {
                await _signInManager.SignOutAsync();
            }

            if (redirect == "TenantRegistration")
            {
                return RedirectToAction("SelectEdition", "TenantRegistration");
            }

            return AbpSession.UserId.HasValue ?
                RedirectToAction("Index", "Home", new { area = "AppAreaName" }) :
                RedirectToAction("Login", "Account");
        }

        public async Task SchedulerNewInvoiceForecastCreatedAsync(int? tenantId, int invoiceForecastCount)
        {
            Logger.Warn("SchedulerNewInvoiceForecastCreatedAsync notification at " + DateTime.Now.ToString() + " : tenantId = " + tenantId.ToString());

            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "SchedulerNewInvoiceForecastCreatedNotificationMessage",
                    DouDianConsts.LocalizationSourceName
                )
            );

            notificationData["invoiceForecastCount"] = invoiceForecastCount;
     
            await _notificationPublisher.PublishAsync(AppNotificationNames.WelcomeToTheApplication, notificationData, severity: NotificationSeverity.Success, tenantIds: new[] { tenantId });
        }
    }
}