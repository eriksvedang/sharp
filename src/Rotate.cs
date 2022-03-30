namespace Jam
{
    using UnityEngine;

    public class Rotate : MonoBehaviour
    {
        public Vector3 rotationSpeed;
        public Space space = Space.World;

        CoherenceSync sync;

        void Awake()
        {
            sync = GetComponent<CoherenceSync>();
        }

        void Update()
        {
            if (sync.isSimulated)
            {
                transform.Rotate(rotationSpeed * Time.deltaTime, space);
            }
        }
    }
}
