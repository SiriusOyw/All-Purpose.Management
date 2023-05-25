using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Zhaoxi.Manage.Common.Extensions;

namespace Zhaoxi.Manage.MentApi.Utility.InitDatabaseExt
{
    public static class AutoInitServiceExt
    {
        /// <summary>
        /// 自动注入服务,必须是同名的接口和实现类,接口必须以I开头,实现类必须以参数endString结尾
        /// </summary>
        /// <param name="services"></param>
        public static void AutoInitService(this IServiceCollection services, string assemblyName, string endString, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            Assembly assembly = Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, assemblyName));
            if (assembly is null) return;
            var types = assembly.GetTypes().Where(type =>
                type.Name.EndsWith(endString) && !type.IsAbstract && !type.IsInterface
            );
            if (types is null) return;
            foreach (Type t in types)
            {
                var i = t.GetInterface($"I{t.Name}");
                if (i is not null)
                    services.Add(i, t, serviceLifetime);
            }
        }

        private static IServiceCollection Add(
            this IServiceCollection collection,
            Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
            ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(descriptor);
            return collection;
        }
    }
}
