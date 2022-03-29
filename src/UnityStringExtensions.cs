namespace Jam
{
    using UnityEngine;

    public class StringEx
    {
        public static string PulsatingDots(float speed = 2f, int dotCount = 3)
        {
            string s = "";
            int dots = 1 + ((int)(Time.time * speed) % dotCount);
            for (int i = 0; i < dots; i++)
            {
                s += ".";
            }
            return s;
        }
    }
}
