using System;
using System.Collections.Generic;

namespace Assignment.Infra.Extensions
{
    /// <summary>
    ///     Enumerable helper methods (extensions)
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Brings some additional data for enumerator
        /// </summary>
        /// <param name="source">Enumerable</param>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <returns>Enumerator detailed</returns>
        public static IEnumerable<IterationElement<T>> Detailed<T>(this IEnumerable<T> source)
        {
            using var enumerator = source.GetEnumerator();
            var isFirst = true;
            var hasNext = enumerator.MoveNext();
            var index = 0;

            while (hasNext)
            {
                var current = enumerator.Current;
                hasNext = enumerator.MoveNext();
                yield return new IterationElement<T>(index, current, isFirst, !hasNext);
                isFirst = false;
                index++;
            }
        }

        /// <summary>
        ///     Struct with additional data for enumerator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public readonly struct IterationElement<T>
        {
            public int Index { get; }
            public bool IsFirst { get; }
            public bool IsLast { get; }
            public T Value { get; }

            public IterationElement(int index, T value, bool isFirst, bool isLast)
            {
                Index = index;
                IsFirst = isFirst;
                IsLast = isLast;
                Value = value;
            }
        }
    }
}