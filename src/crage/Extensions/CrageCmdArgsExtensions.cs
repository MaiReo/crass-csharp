using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.Crage
{
    public static class CrageCmdArgsExtensions
    {
        public static bool IsValid(this CrageCmdArgs cmdArgs)
        {
            if (cmdArgs == null) return false;
            if (string.IsNullOrWhiteSpace(cmdArgs.PackageDir) && string.IsNullOrWhiteSpace(cmdArgs.PackagePath)) return false;
            if ((!string.IsNullOrWhiteSpace(cmdArgs.PackageDir))&&(!string.IsNullOrWhiteSpace(cmdArgs.PackagePath))) return false;
            return true;
        }
    }
}
