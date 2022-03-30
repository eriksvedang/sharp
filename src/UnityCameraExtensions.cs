namespace Jam
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public static class CameraEx
    {
        public static IEnumerable<T> ObjectsAtScreenPoint<T>(this Camera camera, Vector3? screenPoint = null)
        {
            if(screenPoint == null)
            {
                screenPoint = Input.mousePosition;
            }

            var ray = camera.ScreenPointToRay(screenPoint.Value);
            var hits = Physics.RaycastAll(ray);

            foreach(var hit in hits)
            {
                if(hit.transform.TryGetComponent<T>(out T component))
                {
                    yield return component;
                }
            }
        }
    }
}
