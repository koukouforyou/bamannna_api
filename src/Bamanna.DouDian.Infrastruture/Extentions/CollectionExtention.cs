using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bamanna.DouDian.Infrastructure.Extentions
{
    public static class CollectionExtention
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (var item in source)
                func(item);
        }

        public static IEnumerable<IEnumerable<T>> SplitList<T>(this IEnumerable<T> list, int numberOfCopies)
        {
            var result = new List<List<T>>();
            int i = 0;
            while (list.Count() > i * numberOfCopies)
            {
                result.Add(list.Skip(i * numberOfCopies).Take(numberOfCopies).ToList());
                i++;
            }
            return result;
        }

        public static IEnumerable<T> CountIEnumerable<T>(this IEnumerable<IEnumerable<T>> list)
        {
            var result = new List<T>();

            foreach (var item in list)
            {
                result.AddRange(item);
            }

            return result;
        }
    }
}
