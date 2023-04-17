using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player") player = other.gameObject.GetComponentInParent<Player>();
        if (other.gameObject.tag == "Ball" && player != null) player.health.LoseLive();
    }
}
