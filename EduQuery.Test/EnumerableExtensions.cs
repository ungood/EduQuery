using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EduQuery.Test
{
    public static class EnumerableExtensions
    {
        private class ProjectionComparer<T, TKey> : IComparer<T>
        {
            private readonly Func<T, TKey> selector;
            private IComparer<TKey> comparer; 

            public ProjectionComparer(Func<T, TKey> selector, IComparer<TKey> comparer = null)
            {
                this.selector = selector;
                this.comparer = comparer ?? Comparer<TKey>.Default;
            }

            public int Compare(T x, T y)
            {
                return comparer.Compare(selector(x), selector(y));
            }
        }

        public static void AssertSeqeuenceEquals<T>(this IEnumerable<T> actual, params T[] expected)
        {
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
