using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> notAList, Action<T> action)
        {
            notAList.ToList().ForEach(action);
        }
    }
}
