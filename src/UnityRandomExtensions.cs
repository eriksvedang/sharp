namespace Jam
{
    using UnityEngine;

    public static class RandomEx
    {
        public static Color RGB(float min = 0f, float max = 1f)
        {
            return RGBA(min, max).WithAlpha(1f);
        }

        public static Color RGBA(float min = 0f, float max = 1f)
        {
            var r = Random.Range(min, max);
            var g = Random.Range(min, max);
            var b = Random.Range(min, max);
            var a = Random.Range(min, max);
            return new Color(r, g, b, a);
        }
    }
}
