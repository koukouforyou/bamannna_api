using Abp.Domain.Services;
using Abp.Runtime.Session;
using System;
using System.ComponentModel;
using Bamanna.DouDian.Infrastructure.Modules.Filters;

namespace Bamanna.DouDian.Infrastructure.Modules
{
    /// <summary>
    /// 领域服务基类
    /// </summary> 
    public abstract class UnifyDomainServiceBase : DomainService, IUnifyDomainServiceBase
    {
        /* Add your common members for all your domain services. */
        public IAbpSession AbpSession { get; set; }

        public long UserId
        {
            get
            {
                long userId = 0;//当前登录用户
                if (AbpSession != null && AbpSession.UserId.HasValue)
                {
                    userId = AbpSession.UserId.Value;
                }

                return userId;
            }
        }

        public int? TenantId
        {
            get
            {
                int? TenantId = null;//当前登录用户
                if (AbpSession != null && AbpSession.TenantId.HasValue)
                {
                    TenantId = AbpSession.TenantId.Value;
                }

                return TenantId;
            }
        }

        /// <summary>
        /// 执行范围
        /// </summary>
        [DisplayName("执行范围")]
        public virtual DataFilterScopeType DataFilterScope { get; set; }

        protected UnifyDomainServiceBase()
        {
            LocalizationSourceName = UnifyConsts.LocalizationSourceName;
            DataFilterScope = DataFilterHelper.DefaultDataFilterScope;
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <param name="isError">未登录是否抛异常，true则未登录时抛异常</param>
        /// <returns></returns>
        protected virtual bool CheckUserIsLogin(bool isError)
        {
            bool isLogin = AbpSession != null && AbpSession.IsLogin();

            if (isError && !isLogin)
            {
                throw new UnifyDomainException("用户未登录，请登录后再执行相应操作！");
            }

            return isLogin;
        }

        /// <summary>
        /// 设置数据过滤器(未测试通过)
        /// </summary>
        protected virtual IDisposable SetDataFilterScope()
        {
            IDisposable re = null;//DataFilterHelper.GetDataFilterScopeByUser(UserId, CurrentUnitOfWork, DataFilterScope);

            return re;
        }
    }
}
