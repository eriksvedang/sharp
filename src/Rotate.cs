namespace Jam
{
    using UnityEngine;

    public class Rotate : MonoBehaviour
    {
        public Vector3 rotationSpeed;
        public Space space = Space.World;

        void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, space);
        }
    }
}
