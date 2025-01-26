using TMPro;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    public float throwForce = 15f;
    public float lineThrowForce = 5f;
    private Rigidbody2D rb;

    [SerializeField] private GameController gameController;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Line"))
        {
            var normal = other.contacts[0].normal;
            rb.velocity = Vector2.zero;
            rb.AddForce(normal * lineThrowForce, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BaseCollectable>(out BaseCollectable collectable))
        {
            switch(collectable.type)
            {
                case BaseCollectable.Type.WORM:
                    gameController.wormCount++;
                    gameController.UpdateWormText();
                    collectable.Pickup();
                    break;
                case BaseCollectable.Type.BOOSTER:
                    collectable.Pickup(gameObject);
                    break;
            }
        }
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