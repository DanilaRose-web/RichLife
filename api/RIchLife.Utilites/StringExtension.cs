using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIchLife.Utilites
{
    public static class StringExtension
    {
        public static bool HasValue(this string value)
            => !string.IsNullOrWhiteSpace(value);

        public static string UpdateIfHashValue(this string actual, string update)
        {
            if (update.HasValue())
                return actual;
            return update;
        }
    }
}
