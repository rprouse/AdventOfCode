using System;
using System.Collections.Generic;

namespace AdventOfCode.Core
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source,
            Action<TSource> action)
        {
            foreach (TSource item in source)
                action(item);

            return source;
        }

        // Foreach with index
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source,
            Action<TSource, int> action)
        {
            int index = 0;
            foreach (TSource item in source)
                action(item, index++);

            return source;
        }
    }
}
