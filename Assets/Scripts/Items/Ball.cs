using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDuplicated;
    public float speed;

    public Rigidbody rb;
    private Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Player"))
        {
            velocity = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.velocity = velocity * speed;
        }
    }
}