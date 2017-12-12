using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Crass.Plugin.ARCGameEngine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntryBIN
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Name;
        public UInt32 ALFId;     // 所属的ALF封包编号（ALF名称命名按照BIN_index_entry_t中的命名）
        public UInt32 Id;         // 没掌握到分配规则
        public UInt32 Offset;
        public UInt32 Length;
    }
}
