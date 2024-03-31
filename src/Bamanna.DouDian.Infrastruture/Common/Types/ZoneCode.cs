using System;
using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Attributes;
using Bamanna.DouDian.Infrastructure.Types;

namespace Bamanna.DouDian.Infrastructure.Modules
{
    [DataContract]
    [EnumType(DisplayName = "地区类型", Name = "ZoneCode", EnumType = EnumType.Sequence)]
    public enum ZoneCode
    {
        china = 0,
        山东 = 1,
        江苏 = 2,
        上海 = 3,
        浙江 = 4,
        安徽 = 5,
        福建 = 6,
        江西 = 7,
        广东 = 8,
        广西 = 9,
        海南 = 10,
        河南 = 11,
        湖南 = 12,
        湖北 = 13,
        北京 = 14,
        天津 = 15,
        河北 = 16,
        山西 = 17,
        内蒙 = 18,
        宁夏 = 19,
        青海 = 20,
        陕西 = 21,
        甘肃 = 22,
        新疆 = 23,
        四川 = 24,
        贵州 = 25,
        云南 = 26,
        重庆 = 27,
        西藏 = 28,
        辽宁 = 29,
        吉林 = 30,
        黑龙 = 31,
        香港 = 32,
        澳门 = 33,
        台湾 = 34,
    }
}
