namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class LongExtension
    {
        public static long ToLongOrDefault(this string? input, long defaultValue = 0)
        {
            if (input.IsNullOrEmpty())
            {
                return defaultValue;
            }

            if(!long.TryParse(input, out var result)){
                return defaultValue;
            }

            return result;
        }
    }
}
