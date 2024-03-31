using System;
using System.Collections.Generic;
using System.Text;
using Yeban.Infrastructure.Domain;

namespace MyCompanyName.AbpZeroTemplate.Infrastructure.Domain.TreeEntity
{
    public class TreeEntityBase<TPrimary> : UnifyEntityBase<TPrimary>
    {
        public virtual TPrimary Root { get; set; }

        public virtual TPrimary ParentId { get; set; }

        public virtual int Layer { get; set; }

        public virtual string Code { get; set; }

        public virtual int Sort { get; set; }
    }

    public class TreeEntityBase : TreeEntityBase<int>
    {

    }
}
