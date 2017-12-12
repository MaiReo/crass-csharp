using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    public static class PrimitiveTypeExtensions
    {
        public static string AsString(this char[] arr) => new string(arr);

        public static T? AsStruct<T>(this byte[] raw, int index = 0) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buff = raw.Skip(index).Take(size).ToArray();
            if (buff.Length < size) return default(T?);
            
            var handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
            try
            {
                //Marshal the bytes
                return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();//Give control of the buffer back to the GC 
            }
        }
        public static string UnicodeToShiftJIS(this string unicode)
        {
            var unicode_bytes = Encoding.UTF8.GetBytes(unicode);
            var shiftJis = Encoding.GetEncoding(932);
            var shiftJis_bytes = Encoding.Convert(Encoding.UTF8,shiftJis,unicode_bytes);
            return shiftJis.GetString(shiftJis_bytes);
        }

    }
}
