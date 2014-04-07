using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNNspot.Rotator.Common
{
    public static class Extensions
    {

        public static List<int> ToListOfInt(this string source, char tokenSeparator)
        {
            List<string> strings = new List<string>();

            if (!string.IsNullOrEmpty(source))
            {
                string[] csvValues = source.Split(tokenSeparator);
                strings.AddRange(csvValues);
            }

            return strings.ConvertAll<int>(Convert.ToInt32);
        }

        public static List<T> ToList<T>(this ArrayList source)
        {
            return new List<T>((T[])source.ToArray(typeof(T)));
        }
    }
}
