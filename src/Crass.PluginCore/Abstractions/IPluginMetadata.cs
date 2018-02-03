using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PluginCore
{
    public interface IPluginMetadata : IComparable<IPluginMetadata>
    {
        /// <summary>
        /// 封包系统的版权描述信息
        /// </summary>
        string Copyright { get; set; }
        /// <summary>
        /// 封包系统的描述信息
        /// </summary>
        string System { get; set; }
        /// <summary>
        /// 封包扩展名
        /// </summary>
        string Package { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        string Revision { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        string Author { get; set; }
        /// <summary>
        /// 完成日期
        /// </summary>
        string Date { get; set; }
        /// <summary>
        /// 其他信息
        /// </summary>
        string Notion { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        AcuiAttributeLevel AttributeLevel { get; set; }
    }
}
