using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PluginCore
{
    [Flags]
    public enum CuiExtFlag
    {
        /// <summary>
        /// 封包型
        /// </summary>
        CUI_EXT_FLAG_PKG = 0x00000001,
        /// <summary>
        /// 资源型
        /// </summary>
        CUI_EXT_FLAG_RES = 0x00000002,
        /// <summary>
        /// 无扩展名
        /// </summary>
        CUI_EXT_FLAG_NOEXT = 0x00010000,
        /// <summary>
        /// 含目录
        /// </summary>
        CUI_EXT_FLAG_DIR = 0x00020000,
        /// <summary>
        /// 需要额外的索引文件
        /// </summary>
        CUI_EXT_FLAG_LST = 0x00040000,
        /// <summary>
        /// 需要获得额外的配置参数
        /// </summary>
        CUI_EXT_FLAG_OPTION = 0x00080000,
        /// <summary>
        /// 没有magic匹配
        /// </summary>
        CUI_EXT_FLAG_NO_MAGIC = 0x00100000,
        /// <summary>
        /// 尽管没有magic匹配，但是扩展名相对独特
        /// </summary>
        CUI_EXT_FLAG_WEAK_MAGIC = 0x00200000,
        /// <summary>
        /// 对于magic相同的cui，在extract_dir和extract_resource阶段都不算错误 
        /// </summary>
        [Obsolete("CUI_EXT_FLAG_IMPACT", true)]
        CUI_EXT_FLAG_IMPACT = 0x00400000,
        /// <summary>
        /// 后缀名大小写敏感 
        /// </summary>
        CUI_EXT_FLAG_SUFFIX_SENSE = 0x00400000,
        /// <summary>
        /// 资源递归处理
        /// </summary>
        CUI_EXT_FLAG_RECURSION = 0x00800000

    }
}
