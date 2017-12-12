using System;
using System.Runtime.InteropServices;


namespace Crass.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BIN_CompressInfo
    {
        public UInt32 ActualLength;
        public UInt32 UncomprLen;
        public UInt32 ComprLen;
    }
}
