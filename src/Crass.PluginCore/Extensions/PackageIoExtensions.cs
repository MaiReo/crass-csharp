using Crass.PackageCore;
using System;
using System.Runtime.InteropServices;

namespace Crass.PackageCore
{
    public static class PackageIoExtensions
    {
        public static T? ReadStruct<T>(this IPackageIoOperation pio) where T : struct
        {
            var buff = default(byte[]);
            try
            {
                buff = pio.ReadBytes(Marshal.SizeOf<T>());
            }
            catch
            {
            }
            if (buff == null)
            {
                return null;
            }
            return buff.AsStruct<T>();
        }
    }
}
