using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Crass.PackageCore
{
    public class Package : IPackage
    {
        private readonly FileInfo _fileInfo;
        private readonly Lazy<Stream> _lazyStream;

        private Stream Stream => disposedValue ? null : _lazyStream?.Value;

        public Package(string fullPath)
        {
            this._fileInfo = new FileInfo(fullPath);
            _lazyStream = new Lazy<Stream>(() => _fileInfo.OpenRead(), LazyThreadSafetyMode.ExecutionAndPublication);
            PkgRes = new PackageResource();
        }

        public Package(string fullPath, IPackage index, IPackage parent = null) : this(fullPath)
        {
            this.Index = index;
            this.Parent = parent;
        }

        public IPackage Index { get; set; }
        public string Name => _fileInfo.Name;
        public string FullPath => _fileInfo.FullName;
        public string Path => _fileInfo.Name;
        public string ExtensionName => _fileInfo.Extension;
        public IPackage Parent { get; }

        public IPackageResource PkgRes { get; }

        public static IPackage Empty => EmptyPackage.Default;



        public IPackage Seek(long offset, SeekOrigin origin)
        {
            if (Stream?.CanSeek != true) throw new InvalidOperationException();
            Stream?.Seek(offset, origin);
            return this;
        }

        public byte[] ReadBytes(int count)
        {
            if (Stream.CanRead != true) throw new InvalidOperationException();
            using (var reader = new BinaryReader(Stream, Encoding.UTF8, true)) return reader.ReadBytes(count);
        }

        public long GetLength()
        {
            return Stream.Length;
        }
        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_lazyStream.IsValueCreated) _lazyStream.Value.Dispose();
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~PackageIoOperation() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }


        #endregion

    }
}
