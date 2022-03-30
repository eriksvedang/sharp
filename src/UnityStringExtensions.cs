namespace Jam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class StringEx
    {
        public static string TimedSubstring(this string s, float speed = 5f)
        {
            int len = 1 + ((int)(Time.time * speed) % s.Length);
            return s.Substring(0, len);
        }

        public static string Quoted(this string s, string quote = "'")
        {
            return $"{quote}s{quote}";
        }

        public static string JoinBy<A, B>(IEnumerable<A> objects, Func<A, B> converter, string separator)
        {
            return string.Join(separator, objects.Select(o => converter(o)));
        }

        public static string JoinNames<T>(IEnumerable<T> components, string separator = ", ") where T : Component
        {
            return JoinBy(components, c => c.gameObject.name, separator);
        }

        public static string JoinToString<T>(IEnumerable<T> objects, string separator = ", ")
        {
            return JoinBy(objects, FP.Identity, separator);
        }
    }
}
