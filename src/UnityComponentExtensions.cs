namespace Jam
{
    using UnityEngine;

    public static class ComponentEx
    {
        public static T GetComponentOrThrow<T>(this Component self)
        {
            return self.gameObject.GetComponentOrThrow<T>();
        }
    }
}