using System;
using System.Text;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class ExceptionExtension
    {
        public static string CascadingMessage(this Exception ex, int maxDepth = 5)
        {
            StringBuilder builder = new StringBuilder();
            var curEx = ex;
            var count = 0;
            while (curEx != null && count < maxDepth)
            {
                builder.AppendLine(curEx.Message);
                curEx = curEx.InnerException;
                count++;
            }

            return builder.ToString();
        }
    }
}