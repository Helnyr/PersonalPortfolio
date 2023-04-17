using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    private float speed = 7f;
    private float arenaMax = 6f;

    void Update()
    {
        if (isOwned)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            transform.Translate(horizontalMovement * speed * Time.deltaTime, 0, 0, Space.Self);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -arenaMax, arenaMax), transform.position.y, transform.position.z);
        }
    }
}
