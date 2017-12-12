using Crass.PackageCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Crass.Plugin.ARCGameEngine
{
    internal class AB
    {


        public bool TryExtractResourceAB(IPackage package)
        {
            if (!IsMatchAB(package))
            {
                return false;
            }
            if (!TryReadHeaderAB(package, out var header)) return false;

            var compr = default(byte[]);
            try
            {
                compr = package.Pio.ReadBytes((int)header.Info.ComprLen);
            }
            catch
            {
            }

            if (compr == null)
            {
                return false;
            }
            compr = compr.Select(c => (byte)~c).ToArray();

            if (header.Info.ActualLength != header.Info.ComprLen)
            {
                package.PkgRes.ActualData = Util.LzssUncompress(compr, (int)header.Info.UncomprLen);
            }
            else
            {
                package.PkgRes.RawData = compr;
            }

            return true;
        }

        private bool IsMatchAB(IPackage package)
        {
            try
            {
                package.Pio.Seek(0, System.IO.SeekOrigin.Begin);
                var header = package.Pio.ReadStruct<HeaderABMagic>();
                if (!header.HasValue) return false;
                return header.Value.Magic.IsIn("S3AB", "S4AB");
            }
            catch
            {
                return false;
            }

        }

        private bool TryReadHeaderAB(IPackage package, out HeaderAB header)
        {
            try
            {
                package.Pio.Seek(0, System.IO.SeekOrigin.Begin);
                var h = package.Pio.ReadStruct<HeaderAB>();
                header = h ?? default(HeaderAB);
                return h.HasValue;
            }
            catch
            {
                
            }
            header =  default(HeaderAB);
            return false;
        }

    }
}
