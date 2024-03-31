using System;
using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 数据库连接类型
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "数据库连接类型", Name = "DbProviderType")]
    public enum DbProviderType
    {
        /// <summary>
        /// Odbc
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Odbc", Name = "Odbc")]
        Odbc = 1,

        /// <summary>
        /// OleDb
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "OleDb", Name = "OleDb")]
        OleDb = 2,

        /// <summary>
        /// Oracle
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Oracle", Name = "Oracle")]
        Oracle = 4,

        /// <summary>
        /// SqlServer
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "SqlServer", Name = "SqlServer")]
        SqlServer = 8,

        /// <summary>
        /// SqlServerCe
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "SqlServerCe", Name = "SqlServerCe")]
        SqlServerCe = 16
    }
}
