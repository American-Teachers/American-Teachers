using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AtApi.Framework
{
    public static class ExtensionMethods
    {
        [DebuggerStepThrough]
        public static T DeSerialize<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);

        }

        public static string Serlialize(this object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                IgnoreNullValues = true
            };
            return JsonSerializer.Serialize(obj);
        }
    }
}
