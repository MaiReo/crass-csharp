using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Crass.Plugin.ARCGameEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IndexEntryBIN
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string ALFName;
    }
}
