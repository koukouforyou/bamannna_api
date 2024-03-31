using System;
using System.Configuration;

namespace Bamanna.DouDian.Infrastructure.Config
{
    /// <summary>
    /// 节点配置内容集合
    /// </summary>
    public class UnifySettingItems : ConfigurationElementCollection
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public const string _elementName = "add";

        /// <summary>
        /// 创建成员
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new UnifySettingItem();
        }

        /// <summary>
        /// 得到成员
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UnifySettingItem)element).Key;
        }


        /// <summary>
        /// 名称
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return _elementName;
            }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new UnifySettingItem this[string key]
        {
            get
            {
                return (UnifySettingItem)BaseGet(key);
            }
            set
            {
                if (BaseGet(key) != null)
                {
                    BaseRemove(key);
                }
                BaseAdd(value);
            }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UnifySettingItem this[int index]
        {
            get
            {
                return (UnifySettingItem)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
    }
}
