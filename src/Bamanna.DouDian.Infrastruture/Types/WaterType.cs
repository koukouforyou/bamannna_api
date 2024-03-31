using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure
{
    /// <summary>  
    /// 水印类型枚举  
    /// </summary>  
    public enum WaterType
    {
        /// <summary>  
        /// 无水印  
        /// </summary>  
        [EnumMember]
        [EnumValue(DisplayName = "无水印", Name = "No")]
        No =1,
        /// <summary>  
        /// 文字水印  
        /// </summary>  
        [EnumMember]
        [EnumValue(DisplayName = "文字水印", Name = "Text")]
        Text =2,
        /// <summary>  
        /// 图片水印  
        /// </summary>  
        [EnumMember]
        [EnumValue(DisplayName = "图片水印", Name = "Image")]
        Image =3
    }
}
