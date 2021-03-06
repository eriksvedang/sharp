namespace Jam
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MissingComponent : Exception
    {
        public Type missingComponentType;

        public override string Message => missingComponentType.ToString();
    }

    public static class GameObjectEx
    {
        public static T GetComponentOrThrow<T>(this GameObject gameObject)
        {
            if(gameObject.TryGetComponent(out T component))
            {
                return component;
            }
            else
            {
                throw new MissingComponent()
                {
                    missingComponentType = typeof(T)
                };
            }
        }

        public static IEnumerable<T> FindObjectsBy<T>(Func<T, bool> predicate) where T : Component
        {
            return GameObject.FindObjectsOfType<T>().Where(predicate);
        }

        public static IEnumerable<T> FindObjectsWithinSphere<T>(Vector3 center, float radius) where T : Component
        {
            return FindObjectsBy<T>(t => Vector3.Distance(center, t.transform.position) < radius);
        }

        public static IEnumerable<T> InScene<T>(this IEnumerable<T> components, Scene scene) where T : Component
        {
            foreach(var component in components)
            {
                if(component.gameObject.scene == scene)
                {
                    yield return component;
                }
            }
        }
    }
}
