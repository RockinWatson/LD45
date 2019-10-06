using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public Rigidbody2D Rb;

    public Animator animator;

    private Vector2 _movement;

    // Update is called once per frame
    void Update()
    {
        //Register Input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (Rb.velocity.x > 0f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
    }

    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + _movement.normalized * MoveSpeed * Time.fixedDeltaTime);
    }
}
