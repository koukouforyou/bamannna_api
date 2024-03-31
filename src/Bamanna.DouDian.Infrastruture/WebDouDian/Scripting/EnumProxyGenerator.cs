using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamanna.DouDian.Infrastructure.Modules.Common;

namespace Bamanna.DouDian.Infrastructure.Web.WebDouDian.Scripting
{
    public class EnumProxyGenerator : IScriptProxyGenerator
    {
        public EnumProxyGenerator()
        {
        }

        public string Generate()
        {
            var script = new StringBuilder();

            script.AppendLine("{\"enums\":" + EnumDictCol.EnumValueToJson() + ",\"enumTypes\":" + EnumDictCol.EnumTypeToJson() + "}");

            //script.AppendLine("var app = app || {};");
            //script.AppendLine("app.enums =" + EnumDictCol.EnumValueToJson());
            //script.AppendLine("app.enumTypes=" + EnumDictCol.EnumTypeToJson());

            //var app = app || {};
            //app.enums = {
            //    "syncState": { "1": "已提交", "2": "已处理", "3": "同步出错" },
            //    "syncDirection": { "1": "PartnerPortal", "2": "Salesforce" },
            //    "syncActionType": { "1": "新增", "2": "修改" },
            //    "messageTemplateType": { "1": "短信", "2": "邮件" },
            //    "messageSendType": { "1": "单发", "2": "群发" },
            //    "messageSendState": {},
            //    "enumType": { "1": "顺序型", "2": "位域型" },
            //    "enumModule": { "1": "默认模块", "2": "业务模块" }
            //} 原结构修改为现结构，17.12.07 dy

            return script.ToString();
        }
    }
}