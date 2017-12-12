using System.Text;

namespace Crass.Crage
{
    public class ProgramUsage
    {
        static ProgramUsage()
        {
            Current = new ProgramUsage();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Syntax:");
            sb.AppendLine("       crage [[-d dir] | [-p package_file]]");
            sb.AppendLine("       [-l index_file] [-u cui_name] [-o output_dir]");
            sb.AppendLine("       [-n] [-v] [-r] [-h] [-I cui_name] [-i]");
            return sb.ToString();
        }


        public static ProgramUsage Current { get; private set; }
    }
}