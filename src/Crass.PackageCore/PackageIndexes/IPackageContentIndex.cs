namespace Crass.PackageCore
{
    public interface IPackageContentIndex
    {
        string Name { get; }
        long Offset { get; }
        int Length { get; }
    }
}