using UnityEngine;

public partial class PlayerMovement : MonoBehaviour
{
    public float maxThrowForce = 20f;  // Maximum upward force
    public float chargeRate = 10f;     // How quickly the throw force charges per second
    public float minThrowForce = 5f;  // Minimum force required to jump
    private float currentForce;        // The force that is charged
    private bool isCharging;           // Whether the player is holding the jump button
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1; // Ensure gravity is enabled
    }

    void Update()
    {
        // Start charging the jump force when Space is held
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCharging();
        }

        // Stop charging and apply the jump force when Space is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ApplyJump();
        }

        // If charging, increase the currentForce
        if (isCharging)
        {
            ChargeForce();
        }
    }

    void StartCharging()
    {
        isCharging = true;
        currentForce = minThrowForce; // Start from the minimum force
    }

    void ChargeForce()
    {
        currentForce += chargeRate * Time.deltaTime;
        if (currentForce > maxThrowForce)
        {
            currentForce = maxThrowForce; 
        }
    }

    void ApplyJump()
    {
        if (isCharging)
        {
            isCharging = false;

            // Reset current velocity to ensure consistent force application
            rb.velocity = Vector2.zero;

            // Apply the upward force
            rb.AddForce(Vector2.up * currentForce, ForceMode2D.Impulse);

            // Reset the force for the next jump
            currentForce = 0f;
        }
    }
}