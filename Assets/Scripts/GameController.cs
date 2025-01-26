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

    public float wormCount = 0;

    public void UpdateMagnetLevel(float level)
    {
        magnetLevel = level;
        magnetController.UpdateMagnetLevel(level);
    }
    public void UpdateBoosterLevel(float level)
    {
        boosterLevel = level;
    }

    public void UpdatePlayerJumpForce(float force)
    {
        playerController.throwForce = force;
    }


    private void Start(){
        UpdateWormText();
        collectableSpawner.SpawnMoneyWorm(0, moonLevel, wormDensity);
        collectableSpawner.SpawnBooster(0, moonLevel, boosterDensity,boosterLevel);
    
    }

    public void UpdateWormText()
    {
        wormText.text = "Worms: " + wormCount;
    }
}
