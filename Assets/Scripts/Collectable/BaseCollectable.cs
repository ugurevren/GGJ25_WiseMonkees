using UnityEngine;

public class BaseCollectable : MonoBehaviour
{
    public enum Type
    {
        WORM,BOOSTER
    }
    public Type type { get; set; }
    

    //Bunu player controller trigger enter da çağır
    public virtual void Pickup()
    {
        OnPickup();
    }
    public virtual void Pickup(GameObject go)
    {
        OnPickup(go);
    }

    protected virtual void OnPickup()
    {
        
    }
    protected virtual void OnPickup(GameObject go)
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
