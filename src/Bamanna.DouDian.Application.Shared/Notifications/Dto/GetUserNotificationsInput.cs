﻿using System;
using Abp.Notifications;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}