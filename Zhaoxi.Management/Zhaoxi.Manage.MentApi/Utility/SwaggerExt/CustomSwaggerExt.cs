using Microsoft.OpenApi.Models;

namespace Zhaoxi.Manage.MentApi.Utility.SwaggerExt
{
    public static class CustomSwaggerExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwaggerExt(this WebApplicationBuilder builder)
        {
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    option.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = "管理后台Api文档",
                        Version = version,
                        Description = $"通用版本的CoreApi版本{version}",
                    });
                });
                //xml文档绝对路径
                var file = Path.Combine(AppContext.BaseDirectory, "Zhaoxi.Manage.MentApi.xml");
                //true:显示控制器层注释
                option.IncludeXmlComments(file, true);
                //对action的名称进行排序，如果有多个，就可以看见效果了
                option.OrderActionsBy(o => o.RelativePath);
            });
        }

        /// <summary>
        /// 中间件生效 
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExt(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                foreach (var version in typeof(ApiVersions).GetEnumNames())
                {
                    option.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"高级班实战Api第【{version}】版本");
                }
            });
        }
    }
}
