using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public Rigidbody2D Rb;

    public Animator animator;
    public SpriteRenderer Renderer;

    private Vector2 _movement;

    // Update is called once per frame
    void Update()
    {
        //Register Input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //Flip Animation
        if (_movement.x < 0f)
        {
            CostumeManager.Get().FlipRenderersX(true);
            //Renderer.flipX = true;
        }
        if (_movement.x > 0f)
        {
            CostumeManager.Get().FlipRenderersX(false);
            //Renderer.flipX = false;
        }

        //Animations
        if (_movement.x > 0f || _movement.y > 0f || _movement.x < 0f || _movement.y < 0f)
        {
            CostumeManager.Get().SetWalking(true);
        }
        else
        {
            CostumeManager.Get().SetWalking(false);
        }
    }

    void FixedUpdate()
    {
        float adjustedSpeed = CostumeManager.Get().GetSpeedMultiplier(MoveSpeed);
        Rb.MovePosition(Rb.position + _movement.normalized * adjustedSpeed * Time.fixedDeltaTime);
    }
}
