#if UNITY
namespace Jam
{
    using UnityEngine;

    public static class ColorExtensions
    {
        public static Color WithAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        public static Vector3 ToVector3(this Color color)
        {
            return new Vector3(color.r, color.g, color.b);
        }
    }
}
#endif
