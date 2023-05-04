using SqlSugar;
using System.Reflection;

namespace Zhaoxi.Manage.MentApi.Utility.InitDatabaseExt
{
    /// <summary>
    /// 是否初始化数据库
    /// </summary>
    public static class InitDatabaseExt
    {
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="builder"></param>
        public static void InitDatabase(this WebApplicationBuilder builder)
        {
            //读取配置文件中的数据库连接字符串
            string? connectionString = builder.Configuration.GetConnectionString("ConnectionString");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("请配置数据库链接字符串");
            }
            ConnectionConfig connection = new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            };
            //配置SqlSugar--初始化数据库
            using (SqlSugarClient client = new SqlSugarClient(connection))
            {
                //删除数据库--如有--删 否则 不操作
                client.DbMaintenance.CreateDatabase();

                Assembly assembly = Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, "Zhaoxi.Manage.Models.dll"));
                Type[] typeArray = assembly.GetTypes().Where(t=>t.Namespace.Equals("Zhaoxi.Manage.Models.Entity")).ToArray();

                client.CodeFirst.InitTables(typeArray);
            }
        }
    }
}
