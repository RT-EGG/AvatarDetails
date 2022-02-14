using System;
using System.Collections.Generic;

namespace AvatarDetails
{
    public static class EnumerableExtensions
    {
        public static bool TryGetFirst<T>(this IEnumerable<T> inItems, out T outValue, Predicate<T> inComparer)
        {
            foreach (T item in inItems) {
                if (inComparer(item)) {
                    outValue = item;
                    return true;
                }
            }
            outValue = default;
            return false;
        }

        public static void ForEach<T>(this IEnumerable<T> inItems, Action<T> inAction)
        {
            foreach (T item in inItems) {
                inAction(item);
            }
        }

        public static void DisposeItems<T>(this IEnumerable<T> inItems) where T : IDisposable
            => inItems.ForEach(item => item.Dispose());

        public static void DisposeAndClear<T>(this ICollection<T> inItems) where T : IDisposable
        {
            inItems.DisposeItems();
            inItems.Clear();
        }
    }
}
