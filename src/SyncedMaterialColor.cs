using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coherence.Toolkit;

public class SyncedMaterialColor : MonoBehaviour
{
    [Sync]
    public Color color;

    public bool randomizeOnStart;

    private Renderer rend;
    private CoherenceSync sync;

    private void Awake()
    {
        sync = GetComponent<CoherenceSync>();
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        if (sync.HasStateAuthority && randomizeOnStart)
        {
            color = Random.ColorHSV();
        }
    }

    void Update()
    {
        rend.material.color = color;
    }
}
