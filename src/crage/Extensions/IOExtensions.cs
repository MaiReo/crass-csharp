
namespace System.IO
{
    public static class IOExtensions
    {
        private static readonly object _locker = new object();
        public static void EnsureDirectoryIsCreated(this string path)
        {
            if (File.Exists(path))
            {
                throw new InvalidOperationException("Cannot Create directory when the file is already exists");
            }
            if (Directory.Exists(path))
            {
                return;
            }
            lock (_locker)
            {
                Directory.CreateDirectory(path);
            }
            
        }
    }
}
