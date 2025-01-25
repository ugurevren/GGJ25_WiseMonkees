using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    public float throwForce = 15f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyJump();
        }
    }

    void ApplyJump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * throwForce, ForceMode2D.Impulse);
    }
}