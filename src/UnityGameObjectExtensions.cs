namespace Jam
{
    using System;
    using UnityEngine;

    public static class GameObjectEx
    {
        public static void T[] FindObjectsBy(Func<T, bool> predicate) where T : Component
        {
            var objs = FindObjectsOfType<T>();
            var result = new List<T>();

            foreach(var obj in objs)
            {
                if(predicate(obj))
                {
                    result.Add(obj);
                }
            }

            return result.ToArray();
        }
    }
}
