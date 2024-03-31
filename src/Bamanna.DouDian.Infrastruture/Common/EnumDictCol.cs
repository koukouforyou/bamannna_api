using System.Collections.Generic;
using Bamanna.DouDian.Infrastructure.Attributes;
using Bamanna.DouDian.Infrastructure.Extentions;
using Bamanna.DouDian.Infrastructure.Types;
using Bamanna.DouDian.Infrastructure.Utilities;

namespace Bamanna.DouDian.Infrastructure.Modules.Common
{
    public partial class EnumDictCol
    {
        private static string enumValueJson = "";
        private static string enumTypeJson = "";

        public static Dictionary<string, Dictionary<int, string>> EnumsDict => enumValues;
        private static Dictionary<string, Dictionary<int, string>> enumValues = new Dictionary<string, Dictionary<int, string>>();
        private static Dictionary<string, EnumTypeAttribute> enumTypes = new Dictionary<string, EnumTypeAttribute>();

        public static void InitEnumDictCol()
        {
            SetEnumDict<EnumType>();
            SetEnumDict<EnumModule>();
            SetEnumDict<EntityState>();
            SetEnumDict<EntityType>();
            SetEnumDict<GenerationType>();
            SetEnumDict<ResourceType>();
            SetEnumDict<ResGenerationType>();
            SetEnumDict<FieldType>();
            SetEnumDict<DataType>();
            SetEnumDict<RelationshipType>();
            SetEnumDict<ZoneCode>();
            //SetEnumDict<EntityType>();
            //SetEnumDict<GenerationType>();
            //SetEnumDict<DataType>();
            //SetEnumDict<FieldType>();
            //SetEnumDict<RelationshipType>();
            //SetEnumDict<ResGenerationType>();
        }

        public static void SetEnumDict<T>()
        {
            string key = typeof(T).Name.ToCamelCaseName();
            enumValues[key] = EnumUtility<T>.GetValueDisplayNames();

            enumTypes[key] = EnumUtility<T>.GetTypeAttribute();
        }

        public static Dictionary<int, string> GetEnumDict<T>()
        {
            return EnumUtility<T>.GetValueDisplayNames();
        }

        public static string EnumValueToJson()
        {
            if (enumValueJson.Length < 1)
            {
                enumValueJson = enumValues.ToJsonString();
            }

            return enumValueJson;
        }

        public static string EnumTypeToJson()
        {
            if (enumTypeJson.Length < 1)
            {
                enumTypeJson = enumTypes.ToJsonString();
            }

            return enumTypeJson;
        }
    }
}
