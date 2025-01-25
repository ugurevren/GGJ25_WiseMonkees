using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject moneyWormPrefab;
    public GameObject boosterPrefab;

    public float screenHeight = 150f;
    public float screenWidth = 100f;
    public float moonHeight = 15000f;

    public void SpawnMoneyWorm(Vector2 position)
    {
        var moneyFish = Instantiate(moneyWormPrefab, position, Quaternion.identity);
        moneyFish.transform.parent = transform;
        
        /*if (Random.value < -position.y / 8000.0f)
        {
            moneyFish.GetComponent<BaseCollectable>().worth = 3;
        }
        else if (Random.value < -position.y / 25000.0f)
        {
            moneyFish.GetComponent<BaseCollectable>().worth = 5;
        }*/
    }

    private void SpawnBooster(Vector2 position)
    {
        var booster = Instantiate(boosterPrefab, position, Quaternion.identity);
        booster.transform.parent = transform;
    }
    
}
