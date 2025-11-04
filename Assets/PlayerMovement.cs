using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerControler11c : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1000;
    public float sprintmultiplier = 1.5f;           
    public float jumpForce = 300;

    public Transform groundCheck;
    public float groundCheckRadius  = 0.2f;
    public LayerMask whatIsGround;

    public Rigidbody2D rigidbody2;
    public SpriteRenderer spriteRenderer;
    private bool isGrounded;

    [SerializeField] private Animator animator;
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rigidbody2.linearVelocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rigidbody2.linearVelocity.y);
       
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        float currentMoveSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed *= sprintmultiplier;
        }

        rigidbody2.linearVelocity = new Vector2(moveInput * currentMoveSpeed * Time.fixedDeltaTime, rigidbody2.linearVelocity.y);
    }

    indexer (Input !=0)
            {
        animator.SetBool("isRunning", true);
    }
    else
    {
        animator.SetBool("isRunning", false);
    }
}


