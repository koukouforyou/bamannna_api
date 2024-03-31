// ***********************************************************************
// Assembly         : Bamanna.DouDian.Infrastructure.Modules.Core
// Author           : david
// Created          : 10-08-2016
//
// Last Modified By : david
// Last Modified On : 10-19-2016
// ***********************************************************************
// <copyright file="UnifyCrudDomainServiceBase.cs" company="Unify">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Abp;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Bamanna.DouDian.Infrastructure.Modules.Filters;
using Bamanna.DouDian.Infrastructure.Types;
using Bamanna.DouDian.Infrastructure.Utilities;
using Yeban.Infrastructure.Domain;
using System.Collections.Generic;
using Bamanna.DouDian.Infrastructure.Extentions;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;

namespace Bamanna.DouDian.Infrastructure.Modules
{

    /// <summary>
    /// 支持Crud领域服务基类
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the t primary key.</typeparam>
    /// <seealso cref="Bamanna.DouDian.Infrastructure.Modules.UnifyDomainServiceBase" />
    /// <seealso cref="Bamanna.DouDian.Infrastructure.Modules.IUnifyCrudDomainServiceBase{TEntity, TPrimaryKey}" />
    public abstract class UnifyCrudDomainServiceBase<TEntity, TPrimaryKey> : UnifyDomainServiceBase, IUnifyCrudDomainServiceBase<TEntity, TPrimaryKey>
    where TEntity : UnifyEntityBase<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the self repo.
        /// </summary>
        /// <value>The self repo.</value>
        public IRepository<TEntity, TPrimaryKey> SelfRepo { get; set; }

        public virtual IRepository<TEntity, TPrimaryKey> GetSelfRepo()
        {
            return SelfRepo;
        }

        #region Async
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;TPrimaryKey&gt;.</returns>
        public virtual async Task<TPrimaryKey> CreateAsync(TEntity entity)
        {
            SetEntityUserId(entity, ActionsType.Create);

            var re = await SelfRepo.InsertAndGetIdAsync(entity);
            return re;
        }


        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            using (SetDataFilterScope())
            {
                SetEntityUserId(entity, ActionsType.Update);

                await SelfRepo.UpdateAsync(entity);

                return true;
            }
        }

        /// <summary>
        /// 得到实体（如果找不到实体则抛出异常）
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        /// <exception cref="UnifyDomainException"></exception>
        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            using (SetDataFilterScope())
            {
                var re = await SelfRepo.FirstOrDefaultAsync(id);
                if (re == null)
                {
                    throw new UnifyDomainException(string.Format("未找到Id为[{0}]的数据对象[{1}]。", id, AttributeUtility.GetEntityDisplayName<TEntity>()));
                }

                return re;
            }
        }

        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            using (SetDataFilterScope())
            {
                var result = await SelfRepo.FirstOrDefaultAsync(id);
                return result;
            }
        }

        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (SetDataFilterScope())
            {
                return await SelfRepo.FirstOrDefaultAsync(predicate);
            }
        }

        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="ordering">排序参数，exam：CreationTime DESC</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string ordering)
        {
            using (SetDataFilterScope())
            {
                return await SelfRepo.GetAll().AsNoTracking().Where(predicate).OrderBy(ordering).FirstOrDefaultAsync();
            }
        }

        /// <summary>
        /// 判断是否存在一条数据
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (SetDataFilterScope())
            {
                
                var result = await SelfRepo.GetAll().AsNoTracking().AnyAsync(predicate);
                return result;
            }
        }

        /// <summary>
        /// 判断是否存相同数据（如果存在则抛出异常）
        /// bug记录：当某个根节点下添加子节点和根节点name相同时，也会触发该条件。因为根节点的ParentId为自己，但是也不能通过Layer进行判断，因为Layer还未初始化。
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="UnifyDomainException"></exception>
        public virtual async Task<bool> CheckSameRecordAsync(Expression<Func<TEntity, bool>> predicate, params object[] args)
        {
            using (SetDataFilterScope())
            {
                //var tmp= await FirstOrDefaultAsync(predicate);//AnyAsync(predicate);
                TEntity sameEntity = await FirstOrDefaultAsync(predicate); 
                bool hasSame = sameEntity != null;
                if (hasSame)
                {
                    string msg = "";
                    if (args != null && args.Length > 0)
                    {
                        for (int i = 0; i < args.Length; i++)
                        {
                            msg += (i > 0 ? ",{" : "{") + i.ToString() + "}";
                        }
                        msg = "|Detail:" + string.Format(msg, args);
                    }
                    throw new UnifyDomainException(string.Format("找到相同的数据(Id={2}{1}[{3}])在[{0}]表中，请勿重复添加，树形结构相同父节点下不能存在多个Name相同的数据。", AttributeUtility.GetEntityDisplayName<TEntity>(), msg, sameEntity.Id, sameEntity.Name));
                }

                return hasSame;
            }
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> DeleteAsync(TPrimaryKey id)
        {
            using (SetDataFilterScope())
            {
                await SelfRepo.DeleteAsync(id);

                return true;
            }
        }

        /// <summary>
        /// get paged data as an asynchronous operation.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="pageInfo">The page information.</param>
        /// <returns>Task&lt;PagedResult&lt;TEntity, TPrimaryKey&gt;&gt;.</returns>
        public virtual async Task<PagedResult<TEntity, TPrimaryKey>> GetPagedDataAsync(IQueryable<TEntity> query, PagedInfo pageInfo)
        {
            using (SetDataFilterScope())
            {
                if (pageInfo == null)
                {
                    pageInfo = new PagedInfo() { MaxResultCount = 1000, SkipCount = 0, Sorting = "CreationTime Desc" };
                }

                query = query.AsNoTracking();

                var resultCount = 0;
                //if (pageInfo.SkipCount == 0)
                //{
                resultCount = await query.CountAsync();
                //}

                if (!string.IsNullOrEmpty(pageInfo.Sorting))
                {
                    query = query.OrderBy(pageInfo.Sorting);
                }

                query = query.PageBy(pageInfo.SkipCount, pageInfo.MaxResultCount);

                var results = await query
                    .ToListAsync();

                return new PagedResult<TEntity, TPrimaryKey>(resultCount, results);
            }
        }
        #endregion

        #region Sync
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TPrimaryKey.</returns>
        public virtual TPrimaryKey Create(TEntity entity)
        {
            SetEntityUserId(entity, ActionsType.Create);

            return SelfRepo.InsertAndGetId(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Update(TEntity entity)
        {
            using (SetDataFilterScope())
            {
                SetEntityUserId(entity, ActionsType.Update);

                SelfRepo.Update(entity);

                return true;
            }
        }

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            using (SetDataFilterScope())
            {
                return SelfRepo.FirstOrDefault(id);
            }
        }

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            using (SetDataFilterScope())
            {
                return SelfRepo.FirstOrDefault(predicate);
            }
        }

        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="ordering">排序参数，exam：CreationTime DESC</param>
        /// <returns>TEntity.</returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, string ordering)
        {
            using (SetDataFilterScope())
            {
                return SelfRepo.GetAll().Where(predicate).OrderBy(ordering).FirstOrDefault();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Delete(TPrimaryKey id)
        {
            using (SetDataFilterScope())
            {
                SelfRepo.Delete(id);

                return true;
            }
        }
        #endregion

        /// <summary>
        /// 得到IQueryable
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            var re = SelfRepo.GetAll();

            //var test = re.ToListAsync();

            if (DataFilterHelper.CheckScope(DataFilterScope, DataFilterScopeType.Owner))
            {
                re = re.Where(e => e.OwnerId == UserId);
            }

            return re;

        }

        /// <summary>
        /// 得到IQueryable
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public virtual IQueryable<TEntity> GetAllAsNoTracking()
        {
            return GetAll().AsNoTracking();
        }

        /// <summary>
        /// Gets the repo.
        /// </summary>
        /// <returns>IRepository&lt;TEntity, TPrimaryKey&gt;.</returns>
        public virtual IRepository<TEntity, TPrimaryKey> GetRepo()
        {
            return SelfRepo;
        }

        /// <summary>
        /// 设置用户Id(创建或者删除）
        /// </summary>
        protected virtual void SetEntityUserId(TEntity entity, ActionsType at)
        {
            if ((at & ActionsType.Delete) == ActionsType.Delete)
            {
                entity.IsDeleted = true;
                entity.DeleterUserId = UserId;
            }
            if ((at & ActionsType.Create) == ActionsType.Create)
            {
                entity.LastModifierUserId = UserId;
            }

            if ((at & ActionsType.Create) == ActionsType.Create)
            {
                entity.CreatorUserId = UserId;
                entity.TenantId = TenantId;
            }
        }

        protected virtual void SetTenantId(TEntity entity)
        {
            entity.TenantId = TenantId;
        }
    }

    /// <summary>
    /// 支持Crud领域服务基类主键为Guid
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Bamanna.DouDian.Infrastructure.Modules.UnifyCrudDomainServiceBase{TEntity, System.Guid}" />
    public abstract class UnifyCrudDomainServiceBase<TEntity> : UnifyCrudDomainServiceBase<TEntity, Guid>
        where TEntity : UnifyEntityBase<Guid>
    {
        /// <summary>
        /// The sequential unique identifier
        /// </summary>
        protected static SequentialGuidGenerator SequentialGuid = SequentialGuidGenerator.Instance;

        /// <summary>
        /// create as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        public override async Task<Guid> CreateAsync(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = SequentialGuid.Create();
            }

            return await base.CreateAsync(entity);
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Guid.</returns>
        public override Guid Create(TEntity entity)
        {

            if (entity.Id == Guid.Empty)
            {
                entity.Id = SequentialGuid.Create();
            }

            return base.Create(entity);
        }
    }
}
