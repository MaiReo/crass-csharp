using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Crass.Plugin.ARCGameEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeaderABMagic
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string Magic;
    }
}
