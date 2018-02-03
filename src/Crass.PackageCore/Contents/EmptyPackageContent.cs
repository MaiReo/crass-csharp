namespace Crass.PackageCore
{
    internal sealed class EmptyPackageContent : IPackageContent
    {
        public IPackage Package => Crass.PackageCore.Package.Empty;

        public string Name => string .Empty;

        public byte[] Data => new byte[0];

        public void Dispose()
        {
            
        }
        static EmptyPackageContent()
        {
            Default = new EmptyPackageContent();
        }
        public static readonly IPackageContent Default;
    }
}