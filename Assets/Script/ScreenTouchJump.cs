using UnityEngine;

public class ScreenTouchJump : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ekrana dokunma veya t�klama
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
            Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas etti�inde z�plamaya izin ver
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
