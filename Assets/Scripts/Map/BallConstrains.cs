using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConstrains : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.GetComponent<Ball>().rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.GetComponent<Ball>().rb.constraints = RigidbodyConstraints.None;
        }
    }
}
