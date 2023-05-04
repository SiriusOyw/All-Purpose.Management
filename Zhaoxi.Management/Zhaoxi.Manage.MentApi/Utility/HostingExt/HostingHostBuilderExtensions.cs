namespace Zhaoxi.Manage.MentApi.Utility.HostingExt
{
    public static class HostingHostBuilderExtensions
    {
        public const string AppSettingsSecretJsonPath = "appsettings.secrets.json";

        public static IHostBuilder AddAppSettingsSecretsJson(
            this IHostBuilder hostBuilder,
            bool optional = true,
            bool reloadOnChange = true,
            string path = AppSettingsSecretJsonPath)
        {
            return hostBuilder.ConfigureAppConfiguration((_, builder) =>
            {
                builder.AddJsonFile(
                    path: AppSettingsSecretJsonPath,
                    optional: optional,
                    reloadOnChange: reloadOnChange
                );
            });
        }
    }
}
