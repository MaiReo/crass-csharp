using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PluginCore
{
    [Flags]
    public enum AcuiAttributeLevel : uint
    {
        /// <summary>
        /// 未定义
        /// </summary>
        ACUI_ATTRIBUTE_LEVEL_UNKNOWN = 0x00000000,
        /// <summary>
        ///  功能不完善，尚在开发中 
        /// </summary>
        ACUI_ATTRIBUTE_LEVEL_DEVELOP = 0x00000001,
        /// <summary>
        ///  功能虽然完善，但是不稳定 
        /// </summary>
        ACUI_ATTRIBUTE_LEVEL_UNSTABLE = 0x00000002,
        /// <summary>
        ///  功能完善且稳定 
        /// </summary>
        ACUI_ATTRIBUTE_LEVEL_STABLE = 0x00000003,
        /// <summary>
        ///   支持64位操作 
        /// </summary>
        [Obsolete("Will not be supported in CSharp", true)]
        ACUI_ATTRIBUTE_SUPPORT64 = 0x40000000,
        /// <summary>
        ///   多线程安全 
        /// </summary>
        [Obsolete("Will not be supported in CSharp", true)]
        ACUI_ATTRIBUTE_MT_SAFE = 0x80000000,
        /// <summary>
        ///  支持资源预读 
        /// </summary>
        ACUI_ATTRIBUTE_PRELOAD = 0x01000000	
    }
}
