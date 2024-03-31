using Abp.Application.Services;
using Abp.Authorization;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Bamanna.DouDian.Infrasturcture.Modules.Common.Dto;
using Bamanna.DouDian.Infrastructure.Modules.Common.Dto;

namespace Bamanna.DouDian.Infrasturcture.Modules
{
    /// <summary>
    /// All application services in this application is derived from this class.
    /// We can add common application service methods here.
    /// </summary>
    public abstract class UnifyAppServiceBase : ApplicationService
    {
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

        protected virtual int? GetTenantId()
        {
            return (AbpSession != null && AbpSession.TenantId.HasValue) ? AbpSession.TenantId : null;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        /// <summary>
        /// 判断用户是否授权，如果未授权是抛出异常
        /// </summary>
        /// <param name="permissionName">权限名</param>
        public virtual void Authorize(string permissionName)
        {
            PermissionChecker.Authorize(permissionName);
            //A user can not reach this point if he is not granted for permissionName permission.
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <param name="isError">未登录是否抛异常，true则未登录时抛异常</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Abp.UI.UserFriendlyException">用户未登录，请登录后再执行相应操作！</exception>
        protected virtual bool CheckUserIsLogin(bool isError)
        {
            bool isLogin = AbpSession != null && AbpSession.IsLogin();

            if (isError && !isLogin)
            {
                throw new UserFriendlyException("用户未登录，请登录后再执行相应操作！");
            }

            return isLogin;
        }


        /// <summary>
        /// 判断当前用户是否属于某个角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        //public bool IsCurUserHasRole(string roleName)
        //{
        //    bool isLogin = CheckUserIsLogin(false);
        //    if (isLogin)
        //    {
        //        return UserManager.IsUserHasRole(roleName, AbpSession.UserId.Value);
        //    }

        //    return false;
        //}

        /// <summary>
        /// 转化成JsTreeDto
        /// </summary>
        /// <typeparam name="Dto">The type of the dto.</typeparam>
        /// <param name="dtos">The dtos.</param>
        /// <param name="openLayer">The open layer.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="isNested">if set to <c>true</c> [is nested].</param>
        /// <returns>List&lt;JsTreeDto&gt;.</returns>
        public virtual List<JsTreeDto> ToJsTreeDto<Dto>(IReadOnlyList<Dto> dtos, int openLayer, string allName, int selectedId = 0, bool isNested = false) where Dto : UnifyTreeEntityDtoBase
        {
            List<JsTreeDto> re = new List<JsTreeDto>();

            //if (allName != null)
            //{ re.Add(new JsTreeDto(0, "#", allName, "fa fa-home", true, false, false, null, null)); }

            foreach (var item in dtos)
            {
                //Dictionary<string, string> a_attr = new Dictionary<string, string>();
                //a_attr.Add("name", item.Name);
                //a_attr.Add("displayName", item.DisplayName);
                //string id = item.Id;
                string parent = (item.Layer==1) ? "#" : item.ParentId.ToString();
                parent = isNested ? null : parent;
                JsTreeDto node = new JsTreeDto()
                {
                    id = item.Id,
                    parent = parent,
                    icon = "",//图标
                    Id = item.Id,
                    memberCount = item.Children==null?0:item.Children.Count,
                    state = new JsTreeState(item.Layer < openLayer, !item.IsActive, item.Id == selectedId),
                    text = item.Name,//显示名称，建议为displayname
                    code=item.Code,
                    displayName=item.Name
                    //a_attr = a_attr
                };

                re.Add(node);
            }

            return re;
        }
    }
}