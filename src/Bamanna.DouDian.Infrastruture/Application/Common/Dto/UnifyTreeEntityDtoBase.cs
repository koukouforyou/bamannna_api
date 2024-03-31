using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// 树类通用Dto基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class UnifyTreeEntityDtoBase<TPrimaryKey> : UnifyEntityDtoOutputBase<TPrimaryKey>
    {
        /// <summary>
        /// 根
        /// </summary>
        [DisplayName("根")]
        public virtual TPrimaryKey Root { get; set; }

        /// <summary>
        /// 父
        /// </summary>
        [Required]
        [DisplayName("父")]
        public virtual TPrimaryKey ParentId { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        [DisplayName("层")]
        public virtual int Layer { get; set; }

        /// <summary>
        /// 编码，编码使用逗号做为分隔符
        /// </summary>
        [MaxLength(64)]
        [DisplayName("编码")]
        public virtual string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public virtual int Sort { get; set; }

        ///// <summary>
        ///// 显示名称
        ///// </summary>
        //[DisplayName("显示名称")] 
        //public virtual string DisplayName { get; set; }

        ///// <summary>
        ///// 资源图标
        ///// </summary>
        //[DisplayName("资源图标")]
        //public virtual string Icon { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        /// <value>The children.</value>
        public virtual List<UnifyTreeEntityDtoBase<TPrimaryKey>> Children { get; set; }

        /// <summary>
        /// 根据Code（编码）获得Layer（层）
        /// </summary>
        /// <returns></returns>
        public int GetLayerByCode()
        {
            int len = Code.Split(',').Length;

            return len > 0 ? len : 1;
        }
    }

    /// <summary>
    /// 树类通用Dto基类
    /// </summary>
    public abstract class UnifyTreeEntityDtoBase : UnifyTreeEntityDtoBase<int>
    {
        
    }
}
