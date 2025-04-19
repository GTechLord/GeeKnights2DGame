using UnityEngine;

public class Knightscript : MonoBehaviour

{
    //these are references
    public float KnightSpeed = 5f; //movemnent
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

    }

    void Update()
    {
        //  input from  WASD keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize movement to prevent faster diagonal movement
        movement = movement.normalized;

        // animator parameters
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement.sqrMagnitude > 0);

        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }

    
}

    void FixedUpdate()
    {
        // Add movement to the Rigidbody2D
        rb.linearVelocity = movement * KnightSpeed;
    }
}
