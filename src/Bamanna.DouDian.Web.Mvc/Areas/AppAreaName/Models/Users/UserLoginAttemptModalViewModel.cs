using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Users.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}