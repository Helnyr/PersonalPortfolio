using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{
    private ObjectSpawner objectSpawner;

    void Start()
    {
        objectSpawner = GetComponentInParent<ObjectSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            objectSpawner.activeBalls.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
