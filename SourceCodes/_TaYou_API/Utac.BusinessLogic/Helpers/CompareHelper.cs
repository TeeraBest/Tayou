using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.BusinessLogic.Helpers
{
    public static class CompareHelper
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, T, bool> comparer)
        {
            return enumerable.Distinct(new LambdaComparer<T>(comparer));
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        private class LambdaComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _lambdaComparer;
            private readonly Func<T, int> _lambdaHash;

            public LambdaComparer(Func<T, T, bool> lambdaComparer) :
                this(lambdaComparer, o => 0)
            {
            }

            public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
            {
                if (lambdaComparer == null)
                    throw new ArgumentNullException("lambdaComparer");
                if (lambdaHash == null)
                    throw new ArgumentNullException("lambdaHash");

                _lambdaComparer = lambdaComparer;
                _lambdaHash = lambdaHash;
            }

            public bool Equals(T x, T y)
            {
                return _lambdaComparer(x, y);
            }

            public int GetHashCode(T obj)
            {
                return _lambdaHash(obj);
            }
        }

        public static bool VerifyNullHeaderKey(IEnumerable<string> val)
        {
            if (val == null || !val.Any() || string.IsNullOrWhiteSpace(val.FirstOrDefault()))
            {
                return true;
            }

            return false;
        }
    }
}
