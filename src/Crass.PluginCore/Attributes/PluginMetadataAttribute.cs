using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crass.PluginCore
{
    /// <summary>
    /// aui/cui导出信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PluginMetadataAttribute : Attribute, IPluginMetadata
    {
        /// <summary>
        /// aui/cui导出信息
        /// </summary>
        /// <param name="copyright">封包系统的版权描述信息</param>
        /// <param name="system">封包系统的描述信息</param>
        /// <param name="package">封包扩展名</param>
        /// <param name="revision">版本</param>
        /// <param name="author">作者</param>
        /// <param name="date">完成日期</param>
        /// <param name="notion">其他信息</param>
        /// <param name="attributeLevel">属性</param>
        public PluginMetadataAttribute(string copyright = null, string system = null, string package = null,
            string revision = null, string author = null,
            string date = null, string notion = null,
            AcuiAttributeLevel attributeLevel = AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_UNKNOWN)
        {
            Copyright = copyright;
            System = system;
            Package = package;
            Revision = revision;
            Author = author;
            Date = date;
            Notion = notion;
            AttributeLevel = attributeLevel;
        }
        /// <summary>
        /// 封包系统的版权描述信息
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// 封包系统的描述信息
        /// </summary>
        public string System { get; set; }
        /// <summary>
        /// 封包扩展名
        /// </summary>
        public string Package { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Revision { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 完成日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 其他信息
        /// </summary>
        public string Notion { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public AcuiAttributeLevel AttributeLevel { get; set; }


        public override bool Equals(object obj) => this.equals(obj);

        public override bool Match(object obj) => equals(obj);

        public override int GetHashCode() => this.System?.GetHashCode() ?? 0;

        public int CompareTo(IPluginMetadata other) => this.compareTo(other);

        private int compareTo(IPluginMetadata other)
        {
            return (
                this.Copyright?.CompareTo(other?.Copyright)
                + this.System?.CompareTo(other?.System)
                + this.Package?.CompareTo(other?.Package)
                + this.Revision?.CompareTo(other?.Revision)
                + this.Author?.CompareTo(other?.Author)
                + this.Date?.CompareTo(other?.Date)
                + this.Notion?.CompareTo(other?.Notion)
                + this.AttributeLevel.CompareTo(other?.AttributeLevel)
                ) ?? 0;


        }


        private bool equals(object obj)
        {
            if (obj is IPluginMetadata metaData)
            {
                return compareTo(metaData) == 0;
            }
            return object.ReferenceEquals(this, obj);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Copyright:".PadRight(11))
            .AppendLine(this.Copyright)
            .Append("System:".PadRight(11))
            .AppendLine(this.System)
            .Append("Package:".PadRight(11))
            .AppendLine(this.Package)
            .Append("Revision:".PadRight(11))
            .AppendLine(this.Revision)
            .Append("Author:".PadRight(11))
            .AppendLine(this.Author)
            .Append("Date:".PadRight(11))
            .AppendLine(this.Date)
            .Append("Notion:".PadRight(11))
            .AppendLine(this.Notion)
            .Append("Status:".PadRight(11))
            .Append(this.GetAttributeLevelString());
           
            return sb.ToString();
        }

        private string GetAttributeLevelString()
        {
            if (AttributeLevel == AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_UNKNOWN)
            {
                return "未定义";
            }

            var attr = new HashSet<string>();

            if ((AttributeLevel & AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_DEVELOP) == AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_DEVELOP)
            {
                attr.Add("开发中");
            }
            if ((AttributeLevel & AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_UNSTABLE) == AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_UNSTABLE)
            {
                attr.Add("不稳定");
            }
            if ((AttributeLevel & AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_STABLE) == AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_STABLE)
            {
                attr.Add("稳定");
            }
            if ((AttributeLevel & AcuiAttributeLevel.ACUI_ATTRIBUTE_PRELOAD) == AcuiAttributeLevel.ACUI_ATTRIBUTE_PRELOAD)
            {
                attr.Add("支持预读");
            }

            return attr.Any() ? string.Join(" ", attr) : string.Empty;
        }
    }
}
