using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class ObjectExtension
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static IEnumerable<T> ValueOrEmpty<T>(this IEnumerable<T>? items)
        {
            if (items?.Any() != true)
            {
                return Enumerable.Empty<T>();
            }

            return items;
        }
    }
}