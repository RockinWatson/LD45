using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public Rigidbody2D Rb;

    private Vector2 _movement;

    // Update is called once per frame
    void Update()
    {
        //Register Input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + _movement.normalized * MoveSpeed * Time.fixedDeltaTime);
    }
}
