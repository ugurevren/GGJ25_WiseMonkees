using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float magnetLevel = 0f;

    public void UpdateMagnetLevel(float level)
    {
        magnetLevel = level;
        var collider = GetComponent<CircleCollider2D>();
        collider.radius = level*2;
    }
    
    private void Update(){
        gameObject.transform.position=player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<MoneyWorm>(out MoneyWorm worm))
        {
            worm.Magnetized(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<MoneyWorm>(out MoneyWorm worm))
        {
            worm.Demagnetized();
        }
    }
}
