using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public static class LinqExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> notAList, Action<T> action)
        {
            notAList.ToList().ForEach(action);
        }
    }
}
