using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDM.Infrastructure.Modules.Application.Common.Dto
{
    public class TemplateFormDto
    {
        /// <summary>
        /// 生成表单的label标签
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 一个list集合中仅包含一个field，field为Word文档的书签或域值或属性值(目前仅支持书签)
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// 目前仅仅支持text文本框
        /// </summary>
        public string type { get; set; } 
        /// <summary>
        /// field键的值
        /// </summary>
        public string fieldValue { get; set; }
    }
}
