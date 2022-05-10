using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public Vector3 amount;
    public Vector3 freq;

    void Update()
    {
        transform.localPosition =
            new Vector3(Mathf.Sin(Time.time * freq.x) * amount.x,
                        Mathf.Sin(Time.time * freq.y) * amount.y,
                        Mathf.Sin(Time.time * freq.z) * amount.z);
    }
}
