using System;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class DoubleExtension
    {
        public static string? ToRoundedString(this double? number, int decimals = 2, string? defaultValue = null)
        {
            if (!number.HasValue)
            {
                return defaultValue;
            }

            return number.Value.ToRoundedString(decimals, defaultValue);
        }

        public static string? ToRoundedString(this double number, int decimals = 2, string? defaultValue = null)
        {
            return Math.Round(number, decimals).ToString();
        }
    }
}
