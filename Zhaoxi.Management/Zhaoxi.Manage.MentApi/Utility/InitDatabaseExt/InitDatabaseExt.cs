using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Reflection;
using Zhaoxi.Manage.Models.Entity;

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
            List<Sys_Menu> MenuList = new List<Sys_Menu>();
            Assembly asm = Assembly.GetExecutingAssembly();
            IEnumerable<Type> controlleractionlist = asm.GetTypes()
                .Where(type => typeof(ControllerBase)
                .IsAssignableFrom(type));

            foreach (var controller in controlleractionlist)
            {
                if (controller.IsDefined(typeof(FunctionAttribute), true))
                {
                    FunctionAttribute? attribute = controller.GetCustomAttribute<FunctionAttribute>();
                    Guid guid = Guid.NewGuid();

                    Sys_Menu sysMenu = new Sys_Menu()
                    {
                        Id = guid,
                        ParentId = default,
                        MenuText = attribute?.GetDescription(),
                        MenuType = attribute is null ? (int)MuType.Page : (int)attribute.GetMuType()
                    };

                    MenuList.Add(sysMenu);

                    var mehtodlist = controller.GetMethods()
                        .Where(m => m.IsDefined(typeof(FunctionAttribute), true));

                    foreach (var mehtod in mehtodlist)
                    {
                        FunctionAttribute? childAttribute =
                            mehtod.GetCustomAttribute<FunctionAttribute>();
                        Sys_Menu childMenu = new Sys_Menu()
                        {
                            Id = Guid.NewGuid(),
                            ParentId = guid,
                            FullName = $"{controller.FullName}.{mehtod.Name}",
                            MenuText = childAttribute?.GetDescription(),
                            MenuType = childAttribute is null ? (int)MuType.Btn : (int)childAttribute.GetMuType(),
                            ControllerName = controller.Name.ToLower().Replace("controller", ""),
                            ActionName = mehtod.Name.ToLower()
                        };
                        MenuList .Add(childMenu);
                    }
                }
            }

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
                Type[] typeArray = assembly.GetTypes().Where(t =>
                !t.Name.Equals("Sys_BaseModel") &&
                t.Namespace.Equals("Zhaoxi.Manage.Models.Entity")).ToArray();

                client.CodeFirst.InitTables(typeArray);
                client.Insertable(MenuList).ExecuteCommand();
            }
        }
    }
}
