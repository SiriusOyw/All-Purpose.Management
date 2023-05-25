namespace Zhaoxi.Manage.MentApi.Utility.RegisterExt
{
    public static class CorsServiceExtension
    {
        /// <summary>
        /// 配置支持跨域的策略
        /// </summary>
        /// <param name="builder"></param>
        public static void CorsDomainsPolicy(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                //
                options.AddPolicy("AllCorsDomainsPolicy", corsbuilder =>
                {
                    corsbuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        /// <summary>
        /// 配置生效
        /// </summary>
        /// <param name="app"></param>
        public static void UseCorsDomainsPolicy(this WebApplication app) =>
            app.UseCors("AllCorsDomainsPolicy");
    }
}
