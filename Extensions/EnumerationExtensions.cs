using System;
using System.Collections.Generic;

namespace StandardLib.Extensions
{
    public static class EnumerationExtensions
    {
        public static void Each<T>(this IEnumerable<T> source, Action<T> method)
        {
            foreach(var itm in source)
            {
                method.Invoke(itm);
            }
        }
    }
}
