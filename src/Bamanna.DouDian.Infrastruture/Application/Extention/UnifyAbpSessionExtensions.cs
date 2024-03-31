using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian
{
    /// <summary>
    /// AbpSession扩展类
    /// </summary>
    public static class UnifyAbpSessionExtensions
    {
        /// <summary>
        /// Determines whether the specified session is login.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns><c>true</c> if the specified session is login; otherwise, <c>false</c>.</returns>
        public static bool IsLogin(this IAbpSession session)
        {
            return session.UserId.HasValue;
        }
    }
}
