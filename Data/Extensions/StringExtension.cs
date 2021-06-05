using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool HasText([NotNullWhen(true)] this string? input)
        {
            return !input.IsNullOrEmpty();
        }

        public static string ToShortString(this string input, int maxLength = 20, string elipse = "...")
        {
            if (input.IsNullOrEmpty() || input.Length <= maxLength)
            {
                return input;
            }

            return input.Substring(0, maxLength) + elipse;
        }

        public static string? ToNullIfEmpty(this string? input)
        {
            if (input.IsNullOrEmpty())
            {
                return null;
            }

            return input;
        }

        public static bool ContainsAll(this string? input, IEnumerable<string>? items)
        {
            if (input == null)
            {
                throw new NullReferenceException("string is null");
            }

            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (items.Any() != true)
            {
                return true;
            }

            return items.All(input.Contains);
        }

        public static bool ContainsAllInOrder(this string input, string[] items)
        {
            if (!input.ContainsAll(items))
            {
                return false;
            }

            var tmpInput = input;
            foreach (var item in items)
            {
                var newIndex = tmpInput.IndexOf(item, StringComparison.InvariantCulture);
                if (newIndex < 0)
                {
                    return false;
                }

                tmpInput = tmpInput.Substring(Math.Min(newIndex + item.Length, tmpInput.Length - 1));
            }

            return true;
        }

        public static int ToIntOrDefault(this string input, int defaultValue = 0)
        {
            if(!int.TryParse(input, out var result))
            {
                result = defaultValue;
            }

            return result;
        }
    }
}