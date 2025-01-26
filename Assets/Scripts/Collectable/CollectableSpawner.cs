using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject moneyWormPrefab;
    public GameObject boosterPrefab;
    
    public float screenWidth = 8f;
    public float moonHeight = 15000f;
    
    public void SpawnMoneyWorm(float bottomLimit, float topLimit, float amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var position = new Vector2(Random.Range(-screenWidth, screenWidth), Random.Range(bottomLimit, topLimit));
            var moneyFish = Instantiate(moneyWormPrefab, position, Quaternion.identity);
            moneyFish.transform.parent = transform;
        }
    }

    public void SpawnBooster(float bottomLimit, float topLimit, float amount, float boosterLevel)
    {
        for (int i = 0; i < amount; i++)
        {
            var position = new Vector2(Random.Range(-screenWidth, screenWidth), Random.Range(bottomLimit, topLimit));
            var booster = Instantiate(boosterPrefab, position, Quaternion.identity);
            booster.transform.parent = transform;
            booster.GetComponent<Boost>().boosterLevel = boosterLevel;
        }
    }

    
}
