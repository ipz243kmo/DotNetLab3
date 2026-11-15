using System;
using System.Collections.Generic;

namespace ExtensionsDemo
{
    public static class ExtensionMethods
    {
     
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int CountChar(this string str, char target)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int count = 0;
            foreach (char c in str)
            {
                if (c == target)
                    count++;
            }
            return count;
        }

        public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int count = 0;
            foreach (T item in array)
            {
                if (item != null && item.Equals(value))
                {
                    count++;
                }
                else if (item == null && value == null)
                {
                    count++;
                }
            }
            return count;
        }

        public static T[] GetUniqueElements<T>(this T[] array) where T : IEquatable<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            List<T> uniqueList = new List<T>();
            foreach (T item in array)
            {
                if (!uniqueList.Contains(item))
                {
                    uniqueList.Add(item);
                }
            }
            return uniqueList.ToArray();
        }
    }
}