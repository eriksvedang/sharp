namespace Jam
{
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
    }
}
