using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 数据类型(整个系统中的通用数据类型）
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "数据类型", Name = "DynamicDataType")]
    public enum DynamicDataType
    {
        /// <summary>
        /// Bit
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Bit", Name = "Bit")]
        Bit = 0,

        /// <summary>
        /// Uniqueidentifier
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Uniqueidentifier", Name = "Uniqueidentifier")]
        Uniqueidentifier = 1,

        /// <summary>
        /// Timestamp
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Timestamp", Name = "Timestamp")]
        Timestamp = 2,

        /// <summary>
        /// Identity
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Identity", Name = "Identity")]
        Identity = 3,

        /// <summary>
        /// Float
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Float", Name = "Float")]
        Float = 4,
        /// <summary>
        /// Real
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Real", Name = "Real")]
        Real,

        /// <summary>
        /// Datetime
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Datetime", Name = "Datetime")]
        Datetime = 8,
        /// <summary>
        /// Date
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Date", Name = "Date")]
        Date,
        /// <summary>
        /// Datetimeoffset
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Datetimeoffset", Name = "Datetimeoffset")]
        Datetimeoffset,
        /// <summary>
        /// Datetime2
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Datetime2", Name = "Datetime2")]
        Datetime2,
        /// <summary>
        /// Smalldatetime
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Smalldatetime", Name = "Smalldatetime")]
        Smalldatetime,
        /// <summary>
        /// Time
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Time", Name = "Time")]
        Time,

        /// <summary>
        /// Char
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Char", Name = "Char")]
        Char = 16,
        /// <summary>
        /// Varchar
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Varchar", Name = "Varchar")]
        Varchar,
        /// <summary>
        /// Nchar
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Nchar", Name = "Nchar")]
        Nchar,
        /// <summary>
        /// Nvarchar
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Nvarchar", Name = "Nvarchar")]
        Nvarchar,

        /// <summary>
        /// Int
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Int", Name = "Int")]
        Int = 32,
        /// <summary>
        /// Bigint
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Bigint", Name = "Bigint")]
        Bigint,
        /// <summary>
        /// Smallint
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Smallint", Name = "Smallint")]
        Smallint,
        /// <summary>
        /// Tinyint
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Tinyint", Name = "Tinyint")]
        Tinyint,
        /// <summary>
        /// Decimal
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Decimal", Name = "Decimal")]
        Decimal,
        /// <summary>
        /// Numeric
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Numeric", Name = "Numeric")]
        Numeric,
        /// <summary>
        /// Money
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Money", Name = "Money")]
        Money,
        /// <summary>
        /// Smallmoney
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Smallmoney", Name = "Smallmoney")]
        Smallmoney,

        /// <summary>
        /// Binary
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Binary", Name = "Binary")]
        Binary = 64,
        /// <summary>
        /// Image
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Image", Name = "Image")]
        Image,
        /// <summary>
        /// Varbinary
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Varbinary", Name = "Varbinary")]
        Varbinary,
        /// <summary>
        /// VarbinaryMax
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "VarbinaryMax", Name = "VarbinaryMax")]
        VarbinaryMax,

        /// <summary>
        /// Sql_variant
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Sql_variant", Name = "Sql_variant")]
        Sql_variant = 128,
        /// <summary>
        /// Ntext
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Ntext", Name = "Ntext")]
        Ntext,
        /// <summary>
        /// Text
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Text", Name = "Text")]
        Text,
        /// <summary>
        /// NvarcharMax
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "NvarcharMax", Name = "NvarcharMax")]
        NvarcharMax,
        /// <summary>
        /// VarcharMax
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "VarcharMax", Name = "VarcharMax")]
        VarcharMax,
        /// <summary>
        /// XML
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Xml", Name = "Xml")]
        Xml,

        /// <summary>
        /// Picklist
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Picklist", Name = "Picklist")]
        Picklist = 4096,
        /// <summary>
        /// Lookup
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Lookup", Name = "Lookup")]
        Lookup,
        /// <summary>
        /// Primarykey
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Primarykey", Name = "Primarykey")]
        Primarykey,
        /// <summary>
        /// Customer
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Customer", Name = "Customer")]
        Customer,
        /// <summary>
        /// Owner
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Owner", Name = "Owner")]
        Owner,
        /// <summary>
        /// State
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "State", Name = "State")]
        State,
        /// <summary>
        /// Status
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Status", Name = "Status")]
        Status,
    }
}
