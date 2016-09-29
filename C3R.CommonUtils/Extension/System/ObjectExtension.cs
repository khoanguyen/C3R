using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ObjectExtension
    {
        [Conditional("DEBUG")]
        public static void DebugInfo(this object obj, string message)
        {
            Debug.WriteLine($"[{DateTime.Now} - {obj.GetType().FullName}] {message}");
        }
    }
}
