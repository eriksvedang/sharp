namespace Jam
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public static class GameObjectEx
    {
        public static IEnumerable<T> FindObjectsBy<T>(Func<T, bool> predicate, Scene? limitToScene = null) where T : Component
        {
            var objs = GameObject.FindObjectsOfType<T>();

            foreach (var obj in objs)
            {
                if (predicate(obj) && (limitToScene == null || limitToScene == obj.gameObject.scene))
                {
                    yield return obj;
                }
            }
        }

        public static IEnumerable<T> FindObjectsWithin<T>(Vector3 center, float radius, Scene? limitToScene = null) where T : Component
        {
            return FindObjectsBy<T>(t => Vector3.Distance(center, t.transform.position) < radius, limitToScene);
        }
    }
}
