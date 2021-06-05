namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class IntExtension
    {
        public static double ToKiB(this int byteSize)
        {
            return byteSize / 1024.0;
        }

        public static double ToMiB(this int byteSize)
        {
            return byteSize / 1024.0 / 1024.0;
        }

        public static double ToGiB(this int byteSize)
        {
            return byteSize.ToMiB() / 1024.0;
        }

        public static string ToByteString(this int byteSize, int decimals = 2)
        {
            return $"{byteSize} Byte";
        }

        public static string ToKiBString(this int byteSize, int decimals = 2)
        {
            return $"{byteSize.ToKiB().ToString("F")} KiB";
        }

        public static string ToMiBString(this int byteSize, int decimals = 2)
        {
            return $"{byteSize.ToMiB().ToString("F")} MiB";
        }

        public static string ToGiBString(this int byteSize, int decimals = 2)
        {
            return $"{byteSize.ToGiB().ToString("F")} GB";
        }

        public static string ToSizeString(this int byteSize, int decimals = 2)
        {
            if (byteSize < 1024)
            {
                return byteSize.ToByteString(decimals);
            }

            if (byteSize < 1024 * 1024)
            {
                return byteSize.ToKiBString(decimals);
            }

            if (byteSize < 1024 * 1024 * 1024)
            {
                return byteSize.ToMiBString(decimals);
            }

            return byteSize.ToGiBString(decimals);
        }
    }
}