using System.Collections.Generic;
using System.Linq;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> DefaultIfNullOrEmpty<T>(this IEnumerable<T>? items, IEnumerable<T>? defaultItems = null)
        {
            if(items?.Any() != true)
            {
                return defaultItems ?? Enumerable.Empty<T>();
            }
            return items;
        }

    }
}
