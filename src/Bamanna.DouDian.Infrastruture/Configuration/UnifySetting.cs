using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Bamanna.DouDian.Infrastructure.Config
{
    /// <summary>
    /// 自定义节点
    /// </summary>
    public class UnifySetting : ConfigurationElement
    {
        private const string _name = "name";
        private const string _items = "details";

        /// <summary>
        /// 名称
        /// </summary>
        [ConfigurationProperty(_name, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base[_name];
            }
            set
            {
                base[_name] = value;
            }
        }

        /// <summary>
        /// 节点配置内容集合
        /// </summary>
        [ConfigurationProperty(_items, IsDefaultCollection = true)]
        public UnifySettingItems CustomItems
        {
            get
            {
                return (UnifySettingItems)base[_items];
            }
        }
    }
}
