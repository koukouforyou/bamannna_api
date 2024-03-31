using System;
using System.Configuration;

namespace Bamanna.DouDian.Infrastructure.Config
{

    /// <summary>
    /// 自定义节点设置集合
    /// </summary>
    public class UnifySettings : ConfigurationElementCollection
    {
        private const string _elementName = "unifySetting";

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new UnifySetting();
        }

        /// <summary>
        /// 得到节点
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UnifySetting)element).Name;
        }

        /// <summary>
        /// 集合类型
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        /// <summary>
        /// 节点名称
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
        /// <param name="name"></param>
        /// <returns></returns>
        public new UnifySetting this[string name]
        {
            get
            {
                return (UnifySetting)BaseGet(name);
            }
            set
            {
                if (BaseGet(name) != null)
                {
                    BaseRemove(name);
                }
                BaseAdd(value);
            }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UnifySetting this[int index]
        {
            get
            {
                return (UnifySetting)BaseGet(index);
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
