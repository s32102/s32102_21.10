using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerControler11c : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1000;
    public float jumpForce = 300;
    public Rigidbody2D rigidbody2;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rigidbody2.linearVelocity = new Vector2(moveInput *
            moveSpeed *
            Time.deltaTime,
            rigidbody2.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2.AddForce(Vector2.up * jumpForce);
        }
    }
}

