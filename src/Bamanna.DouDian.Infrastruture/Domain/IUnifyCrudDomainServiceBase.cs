using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yeban.Infrastructure.Domain;

namespace Bamanna.DouDian.Infrastructure.Modules
{
    /// <summary>
    /// 支持Crud领域服务接口
    /// </summary>
    public interface IUnifyCrudDomainServiceBase<TEntity, TPrimaryKey> : IUnifyDomainServiceBase
    where TEntity : UnifyEntityBase<TPrimaryKey>
    {
        DataFilterScopeType DataFilterScope { get; set; }

        IRepository<TEntity, TPrimaryKey> GetSelfRepo();


        #region Async

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TPrimaryKey> CreateAsync(TEntity entity);


        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// 得到实体（如果找不到实体则抛出异常）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="ordering">排序参数，exam：CreationTime DESC</param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string ordering);

        /// <summary>
        /// 判断是否存在一条数据
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 判断是否存相同数据（如果存在则抛出异常）
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CheckSameRecordAsync(Expression<Func<TEntity, bool>> predicate,params object[] args);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TPrimaryKey id);


        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="pageInfo">The page information.</param>
        /// <returns>Task&lt;PagedResult&lt;TEntity, TPrimaryKey&gt;&gt;.</returns>
        Task<PagedResult<TEntity, TPrimaryKey>> GetPagedDataAsync(IQueryable<TEntity> query, PagedInfo pageInfo);
        #endregion

        #region Sync
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey Create(TEntity entity);


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="ordering">排序参数，exam：CreationTime DESC</param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, string ordering);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(TPrimaryKey id);
        #endregion

        /// <summary>
        /// 得到IQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();


        /// <summary>
        /// 得到IQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsNoTracking();

        /// <summary>
        /// 得到IRepository
        /// </summary>
        /// <returns></returns>
        //IRepository<TEntity, TPrimaryKey> GetRepo();
    }

    /// <summary>
    /// 支持Crud领域服务接口主键为Guid
    /// </summary>
    public interface IUnifyCrudDomainServiceBase<TEntity> : IUnifyCrudDomainServiceBase<TEntity, Guid>
    where TEntity : UnifyEntityBase<Guid>
    {

    }
}
