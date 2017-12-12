using System;
using System.Linq;

namespace System
{
    public static class GenericCollectionsExtensions
    {
        public static void MemSet<T>(this T[] source, T value, int count) => MemSet<T>(source, value, (uint)count);
        public static void MemSet<T>(this T[] source, T value, uint count)
        {
            count = Math.Min((uint)source.Length, count);

            for (int i = 0; i < count; i++)
            {
                source[i] = value;
            }
        }
        public static bool IsIn<T>(this T @this, params T[] seq)
        {
            return seq.Any(e => object.Equals(e, @this) || object.ReferenceEquals(e, @this));
        }
        public static bool IsNotIn<T>(this T @this, params T[] seq)
        {
            return seq.All(e => (!object.Equals(e, @this)) && (!object.ReferenceEquals(e, @this)));
        }

        public static bool AsStringIn(this char[] arr, params string[] seq) => IsIn(arr.AsString(), seq);
        public static bool AsStringNotIn(this char[] arr, params string[] seq) => IsNotIn(arr.AsString(), seq);

    }
}
