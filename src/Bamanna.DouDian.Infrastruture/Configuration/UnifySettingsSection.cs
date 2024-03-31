using System;
using System.Configuration;

namespace Bamanna.DouDian.Infrastructure.Config
{
    /// <summary>
    /// 自定义ConfigurationSection
    /// </summary>
    [Serializable]
    public class UnifySettingsSection : ConfigurationSection
    {
        private const string _defaultSetting = "defaultSetting";

        /// <summary>
        /// 默认设置
        /// </summary>
        [ConfigurationProperty(_defaultSetting, IsRequired = true)]
        public string DefaultSetting
        {
            get
            {
                return (string)base[_defaultSetting];
            }
            set
            {
                base[_defaultSetting] = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string SectionName
        {
            get
            {
                return this.SectionInformation.Name;
            }
        }

        /// <summary>
        /// 自定义节点设置集合
        /// </summary>
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public UnifySettings CustomSettings
        {
            get
            {
                return (UnifySettings)base[""];
            }
        }
    }
}
