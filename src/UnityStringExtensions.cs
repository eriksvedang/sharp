namespace Jam
{
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

        public static string JoinToString<T>(IEnumerable<T> objs, string separator = ", ")
        {
            return string.Join(separator, objs.Select(o => o.ToString()));
        }

        public static string JoinNames<T>(IEnumerable<T> components, string separator = ", ") where T : Component
        {
            return string.Join(separator, components.Select(component => component.gameObject.name));
        }
    }
}
