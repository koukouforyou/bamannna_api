using Abp;
using Abp.Domain.Uow;
//using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamanna.DouDian.Infrastructure.Filters;

namespace Bamanna.DouDian.Infrastructure.Modules.Filters
{
    public class DataFilterHelper
    {
        /// <summary>
        /// 默认加Owner，Tenant过滤
        /// </summary>
        public static DataFilterScopeType DefaultDataFilterScope
        {
            get
            {
                return DataFilterScopeType.Tenant;
                //return DataFilterScopeType.Owner | DataFilterScopeType.Tenant;
            }
        }

        /// <summary>
        /// 判断默认过滤范围
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CheckDefaultScope(DataFilterScopeType scope)
        {
            return (DefaultDataFilterScope & scope) == scope;
        }

        /// <summary>
        /// 通过传入数据判断过滤范围
        /// </summary>
        /// <param name="data">判断数据</param>
        /// <param name="scope">判断范围</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CheckScope(DataFilterScopeType data, DataFilterScopeType scope)
        {
            return (data & scope) == scope;
        }

        /// <summary>
        /// 设置数据过滤器（暂时实现了Owner，Tenant过滤）
        /// </summary>
        public static IDisposable GetDataFilterScopeByUser(long? userId, IActiveUnitOfWork curUnitOfWork, DataFilterScopeType dataFilterScope)
        {
            IDisposable re = null;
            List<string> enableList = new List<string>();
            List<string> disableList = new List<string>();

            if (curUnitOfWork == null)
            {
                return re;
            }

            if (CheckScope(dataFilterScope,DataFilterScopeType.Owner))
            {
                re = curUnitOfWork.SetFilterParameter(UnifyDataFilters.MayHaveOwner, UnifyDataFilters.Parameters.OwnerId, userId);
            }
            else
            {
                disableList.Add(UnifyDataFilters.MayHaveOwner);
            }

            if ((dataFilterScope & DataFilterScopeType.Tenant) == 0)
            {
                disableList.Add(AbpDataFilters.MayHaveTenant);
            }

            //TODO:Add BusinessUnit


            if (disableList.Count > 0)
            {
                var disableFilter = curUnitOfWork.DisableFilter(disableList.ToArray());
                if (re != null)
                {
                    re = new DisposeAction(() =>
                   {
                       disableFilter.Dispose();
                       re.Dispose();
                   });
                }
                else
                {
                    re = disableFilter;
                }
            }



            return re;
        }
    }
}
