using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCollisionInfo : MonoBehaviour
{
    public Player player;

    private void OnEnable() { player = null; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") player = collision.gameObject.GetComponent<Player>();
    }
}
