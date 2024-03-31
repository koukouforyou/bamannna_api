using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Bamanna.DouDian.EntityFrameworkCore
{
    public static class DouDianDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DouDianDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DouDianDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}