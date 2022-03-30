namespace Jam
{
    using UnityEngine;

    public class SimpleControls : MonoBehaviour
    {
        public float speed = 40f;
        public Space space = Space.World;

        void Update()
        {
            var h = Input.GetAxis("Horizontal") * speed;
            var v = Input.GetAxis("Vertical") * speed;
            transform.Translate(new Vector3(h, 0, v) * Time.deltaTime, space);
        }
    }
}
