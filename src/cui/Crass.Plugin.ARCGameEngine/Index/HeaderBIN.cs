using System.Runtime.InteropServices;

namespace Crass.Plugin.ARCGameEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeaderBIN
    {
        //[MarshalAs(UnmanagedType.ByValTStr,SizeConst = 4)]
        //public string Magic;        // "S3IC", "S3IN", "S4IC", "S4IN"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] Magic;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] version;      // "XXX "
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0xe5)]
        public char[] Title;	//"游戏标题"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x3f)]
        public char[] Unknown; // 可能是一些配置用信息（运行时）
    }
}
