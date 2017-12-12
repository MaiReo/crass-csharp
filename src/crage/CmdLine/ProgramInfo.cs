using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Crass.Crage
{
    public class ProgramInfo
    {
        public ProgramInfo()
        {
        }

        static ProgramInfo()
        {
            Current = new ProgramInfo()
            {
                Prog   = "Crage - a general Galgame resource extractor with cui extensibility",
                Author = "痴漢公賊 <jzhang0@qq.com>",
                Rev    = "0.4.14.1",
                Date   = "2009-7-24 11:29",
                Rel    = "http://galcrass.blog124.fc2.com/"
            };
        }

        string Prog { get; set; }
        string Author { get; set; }
        string Rev { get; set; }
        string Date { get; set; }
        string Rel { get; set; }
        
        public override string ToString()
        {
            var props = typeof(ProgramInfo).GetTypeInfo().DeclaredMembers.OfType<PropertyInfo>().Where(prop => prop.CanRead && prop.PropertyType == typeof(string));
            if (props.Any())
            {
                var maxNameLen = props.Max(p => p.Name.Length) + 2;
                return props.Aggregate(new StringBuilder(), (b, p) => b.Append((p.Name + ":").PadRight(maxNameLen)).AppendLine((string)p.GetValue(this)), sb => sb.ToString());
            }

            return Environment.NewLine;
        }

        public static ProgramInfo Current { get; private set; }
    }
}