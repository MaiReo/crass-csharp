using Crass.PackageCore;
using Crass.Structs;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Crass.Plugin.ARCGameEngine
{
    public class IndexExtractor
    {
        public static IPackageIndex ExtractIndex(IPackage package)
        {
            var p = package.Index;
            p.Pio.Seek(0, System.IO.SeekOrigin.Begin);
            var nullHeader = p.Pio.ReadStruct<HeaderBIN>();
            if (!nullHeader.HasValue) return PackageIndex.Empty;
            var header = nullHeader.Value;
            byte[] data = null;
            var dataLength = 0;
            if (header.Magic.AsStringIn("S3IC", "S4IC")) //header每一个字段都少一位?
            {
                var nullComp = p.Pio.ReadStruct<BIN_CompressInfo>();
                if (!nullComp.HasValue) return PackageIndex.Empty;
                var compInfo = nullComp.Value;
                var compr = p.Pio.ReadBytes((int)compInfo.ComprLen);
                if (compInfo.ComprLen != compInfo.ActualLength)
                {
                    var uncompr = Util.LzssUncompress(compr, (int)compInfo.UncomprLen + 2);
                    data = uncompr;
                }
                else
                {
                    data = compr;
                }
                dataLength = (int)compInfo.ActualLength;
            }
            else // "S3IN", "S4IN"
            {
                var len = package.Index.Pio.GetLength();
                var headerSize = Marshal.SizeOf<HeaderBIN>();
                var size = (int)len - headerSize;
                data = package.Pio.ReadBytes(size);
                dataLength = size;
            }
            var dataIndex = 0;

            var indexHeaderBIN = data.AsStruct<IndexHeaderBIN>();
            dataIndex += Marshal.SizeOf<IndexHeaderBIN>();

            if (!indexHeaderBIN.HasValue) return PackageIndex.Empty;

            var indexEntry = new IndexEntryBIN?[indexHeaderBIN.Value.ALFCount];

            var IndexEntryBINSize = Marshal.SizeOf<IndexEntryBIN>();

            for (int i = 0; i < indexHeaderBIN.Value.ALFCount; i++)
            {
                indexEntry[i] = data.AsStruct<IndexEntryBIN>(dataIndex);
                dataIndex += IndexEntryBINSize;
            }
            var packageName = package.Name.UnicodeToShiftJIS();
            var alfId = indexEntry.Select(e => e?.ALFName).TakeWhile(s => s != packageName).Count();
            if (alfId + 1 >= indexEntry.Length) return PackageIndex.Empty;
            var indexEntryHeaderBIN = data.AsStruct<IndexEntryHeaderBIN>(dataIndex);
            if (!indexEntryHeaderBIN.HasValue) return PackageIndex.Empty;
            dataIndex += Marshal.SizeOf<IndexEntryHeaderBIN>();

            var entryBINSize = Marshal.SizeOf<EntryBIN>();
            var entryBIN = new EntryBIN?[indexEntryHeaderBIN.Value.EntriesCount];
            for (int i = 0; i < entryBIN.Length; i++)
            {
                entryBIN[i] = data.AsStruct<EntryBIN>(dataIndex);
                dataIndex += entryBINSize;
            }
            var packageEntryBIN = entryBIN.Where(e => e?.ALFId == alfId).Select(x => x.Value);
            return new PackageIndex(packageEntryBIN.Select(e => new PackageContentIndex() { Length = (int)e.Length, Name = e.Name, Offset = e.Offset }));
        }
    }
}
