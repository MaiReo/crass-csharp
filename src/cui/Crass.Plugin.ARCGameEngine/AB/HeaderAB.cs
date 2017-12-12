using Crass.Structs;
using System;
using System.Runtime.InteropServices;

namespace Crass.Plugin.ARCGameEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeaderAB
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string Magic;  //// "S3AB", "S4AB"
        public UInt32 Unknown0;
        public UInt32 Unknown1;
        public UInt32 ActLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Unknown;
        public BIN_CompressInfo Info;
    }
}
