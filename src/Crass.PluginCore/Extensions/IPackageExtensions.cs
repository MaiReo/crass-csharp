using Crass.PackageCore;
using System;
using System.Runtime.InteropServices;

namespace Crass.PackageCore
{
    public static class IPackageExtensions
    {
        public static T? ReadStruct<T>(this IPackage package) where T : struct
        {
            var buff = default(byte[]);
            try
            {
                buff = package.ReadBytes(Marshal.SizeOf<T>());
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
