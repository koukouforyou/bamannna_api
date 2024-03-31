using System;
using System.Configuration;

namespace Bamanna.DouDian.Infrastructure.Config
{
    /// <summary>
    /// 节点配置内容（键值对）
    /// </summary>
    public class UnifySettingItem : ConfigurationElement
    {
        private const string _key = "key";
        private const string _value = "value";

        /// <summary>
        /// 键
        /// </summary>
        [ConfigurationProperty(_key, IsRequired = true)]
        public string Key
        {
            get
            {
                return (string)base[_key];
            }
            set
            {
                base[_key] = value;
            }
        }

        /// <summary>
        /// 值
        /// </summary>
        [ConfigurationProperty(_value, IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)base[_value];
            }
            set
            {
                base[_value] = value;
            }
        }
    }
}
