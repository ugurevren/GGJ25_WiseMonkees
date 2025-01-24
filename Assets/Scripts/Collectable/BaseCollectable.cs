using UnityEngine;

public class BaseCollectable : MonoBehaviour
{
    public enum Type
    {
        WORM,BOOSTER
    }
    public Type type { get; set; }
    
    public int worth = 1;
   

    //Bunu player controller trigger enter da çağır
    public virtual void Pickup()
    {
        //UI Ekle
        Debug.Log(worth);
        OnPickup();
    }

    protected virtual void OnPickup()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
