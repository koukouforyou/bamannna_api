using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 实体状态
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "实体状态", Name = "EntityState", EnumType = EnumType.Sequence)]
    public enum EntityState
    {
        /// <summary>
        /// 草稿
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "草稿", Name = "Draft", IsDefault = true)]
        Draft = 1,

        /// <summary>
        /// 已保存
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "已保存", Name = "Saved", IsDefault = false)]
        Saved = 2,

        /// <summary>
        /// 已发布
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "已发布", Name = "Published", IsDefault = false)]
        Published = 3,
    }

    /// <summary>
    /// 实体类型
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "实体类型", Name = "EntityType", EnumType = EnumType.Sequence)]
    public enum EntityType
    {
        /// <summary>
        /// 普通实体
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "普通实体", Name = "Normal", IsDefault = true)]
        Normal = 1,

        /// <summary>
        /// 树形实体
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "树形实体", Name = "Tree", IsDefault = false)]
        Tree = 2,

        /// <summary>
        /// 关系实体
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "关系实体", Name = "Relationship", IsDefault = false)]
        Relationship = 3,


        /// <summary>
        /// 简单对象
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "简单对象", Name = "Plain", IsDefault = false)]
        Plain = 4,
    }

    /// <summary>
    /// 生成类型
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "生成类型", Name = "GenerationType", EnumType = EnumType.Flags)]
    public enum GenerationType
    {
        /// <summary>
        /// 生成实体
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "生成实体", Name = "Entity", IsDefault = true)]
        Entity = 1,

        /// <summary>
        /// 生成Dto
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "生成Dto", Name = "Dto", IsDefault = false)]
        Dto = 2,

        /// <summary>
        /// 创建对象
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "创建对象", Name = "Create", IsDefault = false)]
        Create = 4,

        /// <summary>
        /// 删除对象
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "删除对象", Name = "Delete", IsDefault = false)]
        Delete = 8,

        /// <summary>
        /// 更新对象
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "更新对象", Name = "Update", IsDefault = false)]
        Update = 16,


        /// <summary>
        /// 得到对象
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "得到对象", Name = "Get", IsDefault = false)]
        Get = 32,

        /// <summary>
        /// 分页查询
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "分页查询", Name = "PagedQuery", IsDefault = false)]
        PagedQuery = 64,

        /// <summary>
        /// 启用/禁用
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "启用/禁用", Name = "Active", IsDefault = false)]
        Active = 128,
    }
}
