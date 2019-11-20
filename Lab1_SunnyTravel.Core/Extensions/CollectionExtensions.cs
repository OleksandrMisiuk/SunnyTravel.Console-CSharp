using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.GetEnumerator().MoveNext();
        }
    }
}
