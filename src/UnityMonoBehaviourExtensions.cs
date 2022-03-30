namespace Jam
{
    using UnityEngine;

    public static class MonoBehaviourEx
    {
        public static T GetComponentOrThrow<T>(this MonoBehaviour self)
        {
            return self.gameObject.GetComponentOrThrow<T>();
        }
    }
}