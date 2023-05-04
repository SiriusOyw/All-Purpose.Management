using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Manage.Common.Extensions
{
    public static class StringExtensions
    {

        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
        {
            if ((object)value != null && 0u < (uint)value!.Length)
            {
                return false;
            }
            return true;
        }

        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
        {
            if ((object)value == null)
            {
                return true;
            }
            for (int i = 0; i < value!.Length; i++)
            {
                if (!char.IsWhiteSpace(value![i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
