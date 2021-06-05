using System;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class DateTimeExtension
    {
        public static string? ToGermanString(this DateTime? dateTime, string? defaultValue = null)
        {
            if (!dateTime.HasValue)
            {
                return defaultValue;
            }

            return dateTime.Value.ToGermanString(defaultValue);
        }

        public static string? ToGermanString(this DateTime dateTime, string? defaultValue = null)
        {
            return dateTime.ToString("dd.MM.yyyy HH:mm");
        }

        public static string ToShortDayOfMonthGerman(this DateTime dateTime)
        {
            switch (dateTime.Date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Mo";
                case DayOfWeek.Tuesday:
                    return "Di";
                case DayOfWeek.Wednesday:
                    return "Mi";
                case DayOfWeek.Thursday:
                    return "Do";
                case DayOfWeek.Friday:
                    return "Fr";
                case DayOfWeek.Saturday:
                    return "Sa";
                case DayOfWeek.Sunday:
                    return "So";
                default:
                    return "N/A";


            }
        }
    }
}
