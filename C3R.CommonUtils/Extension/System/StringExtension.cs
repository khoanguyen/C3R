using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtension
    {
        public static string ToHexString(this IEnumerable<byte> target)
        {
            var builder = new StringBuilder();
            foreach (var b in target) builder.Append(b.ToString("X2"));
            return builder.ToString();
        }
    }
}
