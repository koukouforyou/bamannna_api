using System;
using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "数据库类型", Name = "DatabaseType")]
    public enum DatabaseType
    {
        /// <summary>
        /// Oracle
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Oracle", Name = "Oracle")]
        Oracle = 32,

        /// <summary>
        /// SqlServer
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "SqlServer", Name = "SqlServer")]
        SqlServer = 64,

        /// <summary>
        /// Mysql
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "Mysql", Name = "Mysql")]
        Mysql = 128,

        /// <summary>
        /// PostgreSQL
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "PostgreSQL", Name = "PostgreSQL")]
        PostgreSQL = 256,

        /// <summary>
        /// SQLite
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "SQLite", Name = "SQLite")]
        SQLite = 512
    }
}
