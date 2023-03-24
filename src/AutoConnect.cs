#if COHERENCE_JAM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coherence.Cloud;
using Coherence.Toolkit;
using Coherence.Connection;
using Coherence;

public class AutoConnect : MonoBehaviour
{
    void Start()
    {
        if (RuntimeSettings.instance.LocalDevelopmentMode)
        {
            ConnectToLocalWorld();
        }
        else
        {
            StartCoroutine(ConnectToCloudWorld());
        }
    }

    IEnumerator ConnectToCloudWorld()
    {
        var cloud = new CloudService();

        while (!cloud.IsReady)
        {
            yield return cloud.WaitForCloudServiceReadyRoutine();
        }

        Debug.Log("Connected to cloud, fetching worlds.");

        cloud.Worlds.FetchWorlds(response =>
        {
            if (response.Status == RequestStatus.Success)
            {
                if (response.Result.Count == 0)
                {
                    Debug.LogError("No cloud world found.");
                }
                else
                {
                    var world = response.Result[0];
                    if (CoherenceManagerStore.TryGetBridge(gameObject.scene, out CoherenceManager manager))
                    {
                        Debug.Log($"Found cloud world '{world.Name}', will try to connect to it.");
                        manager.onConnectionError.AddListener((mgr, e) => Debug.LogError($"Connection error: {e}"));
                        manager.onDisconnected.AddListener((mgr, reason) => Debug.LogError($"Connection closed: {reason}"));
                        manager.JoinWorld(world);
                    }
                    else
                    {
                        Debug.LogError("Failed to get a CoherenceManager.");
                    }
                }
            }
            else
            {
                Debug.LogError("Failed to fetch cloud worlds.");
            }
        });
    }


    void ConnectToLocalWorld()
    {
        if (CoherenceManagerStore.TryGetBridge(gameObject.scene, out CoherenceManager manager))
        {
            manager.onConnected.AddListener(b => Debug.Log("Connected to local world."));

            Debug.Log("Trying to connect to local world.");
            manager.Connect(new EndpointData()
            {
                schemaId = RuntimeSettings.instance.SchemaID,
                region = EndpointData.LocalRegion,
                host = "127.0.0.1",
#if UNITY_WEBGL && !UNITY_EDITOR
                port = 32002,
#else
                port = 32001,
#endif
            });
        }
        else
        {
            Debug.LogError("Failed to get a CoherenceManager.");
        }
    }
}
#endif
