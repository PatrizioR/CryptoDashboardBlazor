using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CryptoDashboardBlazor.Data.Extensions
{
    public static class AssemblyExtension
    {
        public static DateTime? GetBuildDateTime(this Assembly assembly)
        {
            var path = assembly.GetName().CodeBase;
            if (path.HasText() && File.Exists(path))
            {
                var buffer = new byte[Math.Max(Marshal.SizeOf(typeof(_IMAGE_FILE_HEADER)), 4)];
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    fileStream.Position = 0x3C;
                    fileStream.Read(buffer, 0, 4);
                    fileStream.Position = BitConverter.ToUInt32(buffer, 0); // COFF header offset
                    fileStream.Read(buffer, 0, 4); // "PE\0\0"
                    fileStream.Read(buffer, 0, buffer.Length);
                }
                var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                    var coffHeader = (_IMAGE_FILE_HEADER)Marshal.PtrToStructure(pinnedBuffer.AddrOfPinnedObject(), typeof(_IMAGE_FILE_HEADER));
#pragma warning restore CS8605 // Unboxing a possibly null value.
                    return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local) + new TimeSpan(coffHeader.TimeDateStamp * TimeSpan.TicksPerSecond);
                }
                finally
                {
                    pinnedBuffer.Free();
                }
            }
            Console.WriteLine($"Could not get assembly build datetime: {assembly}");
            return null;
        }

#pragma warning disable IDE1006 // Naming Styles

        private struct _IMAGE_FILE_HEADER
        {
            public ushort Machine;
            public ushort NumberOfSections;
            public uint TimeDateStamp;
            public uint PointerToSymbolTable;
            public uint NumberOfSymbols;
            public ushort SizeOfOptionalHeader;
            public ushort Characteristics;
        };

#pragma warning restore IDE1006 // Naming Styles
    }
}