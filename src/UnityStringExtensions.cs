namespace Jam
{
    using UnityEngine;

    public static class StringEx
    {
        public static string TimedSubstring(this string s, float speed = 2f)
        {
            int len = 1 + ((int)(Time.time * speed) % s.Length);
            return s.Substring(len);
        }
    }
}
