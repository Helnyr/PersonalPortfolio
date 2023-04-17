using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            LastCollisionInfo ball = other.gameObject.GetComponent<LastCollisionInfo>();
            
            if (ball.player != null)
            {
                if(CompareTag("PowerUpOne")) ball.player.powerups.GetPowerupOne();
                if(CompareTag("PowerUpTwo")) ball.player.powerups .GetPowerupTwo();
                DestroyObject(gameObject);
            }
        }
    }

    public void DestroyObject(GameObject item)
    {
        ObjectSpawner spawner = FindObjectOfType<ObjectSpawner>();
        spawner.activePowerups.Remove(item);
        Destroy(item);
    }
}
