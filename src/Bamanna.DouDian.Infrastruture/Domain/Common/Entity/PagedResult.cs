using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yeban.Infrastructure.Domain;

namespace Bamanna.DouDian.Infrastructure
{
    public class PagedResult<TEntity, TPrimaryKey> where TEntity : UnifyEntityBase<TPrimaryKey>
    {
        public int TotalCount { get; set; }

        public IReadOnlyList<TEntity> Items { get; set; }

        public PagedResult()
        {
        }

        public PagedResult(int totalCount, IReadOnlyList<TEntity> items)
        {
            TotalCount = totalCount;
            Items = items;
        }
    }

    public class PagedResult<TEntity> where TEntity : UnifyEntityBase<Guid>
    {
        public int TotalCount { get; set; }

        public IReadOnlyList<TEntity> Items { get; set; }

        public PagedResult()
        {
        }

        public PagedResult(int totalCount, IReadOnlyList<TEntity> items)
        {
            TotalCount = totalCount;
            Items = items;
        }
    }
}
