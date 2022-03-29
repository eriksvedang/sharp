namespace Jam
{
    using UnityEngine;

    public class Vector3Ex
    {
        public static Color ToColor(this Vector3 vector)
        {
            return new Color(vector.x, vector.y, vector.z);
        }
    }
}
