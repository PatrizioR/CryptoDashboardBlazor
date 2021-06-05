using System.Drawing;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class ColorExtension
    {
        public static string ToHtmlCode(this Color color)
        {
            return $"#{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
        }
    }
}
