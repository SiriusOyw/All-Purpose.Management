using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Manage.Common
{
    public static class TypeExtensions
    {
        public static string GetFullNameWithAssemblyName(this Type type)
        {
            return type.FullName + ", " + type.Assembly.GetName().Name;
        }

        //
        // 摘要:
        //     确定是否可以将此类型的实例分配给的实例
        //     T目标。在内部使用System.Type.Is Assignable From（System.Type）。
        //
        // 类型参数:
        //   TTarget:
        //     目标类型
        public static bool IsAssignableTo<TTarget>(this Type type)
        {
            Check.NotNull(type, "type");
            return IsAssignableTo(type, typeof(TTarget));
        }

        //
        // 摘要:
        //     确定是否可以将此类型的实例分配给的实例
        //     目标类型。内部使用System.Type.Is Assignable From（System.Type） (as
        //     reverse).
        //
        // 参数:
        //   type:
        //     这种类型
        //
        //   targetType:
        //     目标类型
        public static bool IsAssignableTo(this Type type, Type targetType)
        {
            Check.NotNull(type, "type");
            Check.NotNull(targetType, "targetType");
            return targetType.IsAssignableFrom(type);
        }

        //
        // 摘要:
        //     获取此类型的所有基类。
        //
        // 参数:
        //   type:
        //     要获取其基类的类型。
        //
        //   includeObject:
        //     True，以在返回的数组中包括标准System.Object类型。
        public static Type[] GetBaseClasses(this Type type, bool includeObject = true)
        {
            Check.NotNull(type, "type");
            List<Type> list = new List<Type>();
            AddTypeAndBaseTypesRecursively(list, type.BaseType, includeObject);
            return list.ToArray();
        }

        //
        // 摘要:
        //     获取此类型的所有基类。
        //
        // 参数:
        //   type:
        //     要获取其基类的类型。
        //
        //   stoppingType:
        //     一种停止进入更深层次基类的类型。此类型将包括在内
        //     在返回的数组中
        //
        //   includeObject:
        //     True，以在返回的数组中包括标准System.Object类型。
        public static Type[] GetBaseClasses(this Type type, Type stoppingType, bool includeObject = true)
        {
            Check.NotNull(type, "type");
            List<Type> list = new List<Type>();
            AddTypeAndBaseTypesRecursively(list, type.BaseType, includeObject, stoppingType);
            return list.ToArray();
        }

        private static void AddTypeAndBaseTypesRecursively(List<Type> types, Type type, bool includeObject, Type stoppingType = null)
        {
            if (!(type == null) && !(type == stoppingType) && (includeObject || !(type == typeof(object))))
            {
                AddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject, stoppingType);
                types.Add(type);
            }
        }
    }
}
