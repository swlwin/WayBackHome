using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTransform.localScale.x > 0)
        {
            // Player is facing right
            rb.velocity = transform.right * speed;
        }
        else
        {
            // Player is facing left
            rb.velocity = -transform.right * speed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}