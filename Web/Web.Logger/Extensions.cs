using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Web.Logger
{
    internal static class Extensions
    {
        public static string FormatForException(this string message, Exception ex)
        {
            return $"{message}: {(ex != null ? ex.ToString() : "")}";
        }

        public static string FormatForContext(
            this string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            var methodName = memberName;

            return $"[{fileName}:{methodName}] - {message}";
        }
    }
}
