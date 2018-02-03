namespace Crass.PackageCore
{
    public class PackageContentIndex : IPackageContentIndex
    {
        public string Name { get; set; }
        public long Offset { get; set; }
        public int Length { get; set; }
    }
}