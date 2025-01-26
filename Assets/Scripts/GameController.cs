using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CollectableSpawner collectableSpawner;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI wormText;
    

    [SerializeField] private float wormDensity = 200f;
    [SerializeField] private float boosterDensity = 1f;

    [SerializeField] private float moonLevel = 1500f;

    [SerializeField] MagnetController magnetController;

    
    public float boosterLevel = 1f;
    public float magnetLevel = 1f;

    public float bubbleBounceLevel = 1f;

    public float wormCount = 0;


    public void UpdateMagnetLevel(float level)
    {
        magnetLevel = level;
        magnetController.UpdateMagnetLevel(level); // Done in MagnetController.cs
    }
    public void UpdateBoosterLevel(float level)
    {
        boosterLevel = level; // Done in Boost.cs
    }

    public void UpdatePlayerJumpForce(float force)
    {
        playerController.throwForce = 15f+ (force*5f);
    }

    public void UpdatePlayerLineThrowForce(float force)
    {
        playerController.lineThrowForce = 15f+(force*5f);
    }


    private void Start(){
        UpdateWormText();
        UpdateBoosterLevel(boosterLevel);
        UpdateMagnetLevel(magnetLevel);
        UpdatePlayerJumpForce(1);
        UpdatePlayerLineThrowForce(1);
        
        collectableSpawner.SpawnMoneyWorm(0, moonLevel, wormDensity);
        collectableSpawner.SpawnBooster(0, moonLevel, boosterDensity,boosterLevel);
    
    }

    public void UpdateWormText()
    {
        wormText.text = "Worms: " + wormCount;
    }
}
