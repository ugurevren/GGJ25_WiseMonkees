using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private MagnetController magnetController;
    
    [SerializeField] private float blackPapperPrice = 100f;
    [SerializeField] private TextMeshProUGUI blackPapperPriceText;
    [SerializeField] private TextMeshProUGUI blackPapperLevelText;
    private float blackPapperLevel = 1f;

    [SerializeField] private float boosterPrice = 100f;
    [SerializeField] private TextMeshProUGUI boosterPriceText;
    [SerializeField] private TextMeshProUGUI boosterLevelText;
    private float boosterLevel = 1f;


    [SerializeField] private float magnetPrice = 100f;
    [SerializeField] private TextMeshProUGUI magnetPriceText;
    [SerializeField] private TextMeshProUGUI magnetLevelText;
    private float magnetLevel = 1f;

    public void BuyBlackPapper()
    {
        if (gameController.wormCount >= blackPapperPrice)
        {
            gameController.wormCount -= blackPapperPrice;
            playerController.throwForce += 5f;
            gameController.UpdateWormText();
            blackPapperPrice += 50f;
            blackPapperLevel += 1;
            blackPapperLevelText.text = "Level: " + blackPapperLevel;
            UpdateBlackPapperPrice();
        }
    }

    public void BuyBooster()
    {
        if (gameController.wormCount >= boosterPrice)
        {
            gameController.wormCount -= boosterPrice;
            gameController.UpdateBoosterLevel(gameController.boosterLevel + 1);
            gameController.UpdateWormText();
            boosterPrice += 50f;
            boosterLevel += 1;
            boosterLevelText.text = "Level: " + boosterLevel;
            UpdateBoosterPrice();
            
        }
    }

    public void BuyMagnet()
    {
        if (gameController.wormCount >= magnetPrice)
        {
            gameController.wormCount -= magnetPrice;
            gameController.UpdateMagnetLevel(gameController.magnetLevel + 1);
            gameController.UpdateWormText();
            magnetPrice += 50f;
            magnetLevel += 1;
            magnetLevelText.text = "Level: " + magnetLevel;
            UpdateMagnetPrice();
            
        }
    }

    public void UpdateBlackPapperPrice()
    {
        blackPapperPriceText.text = "Price: " + blackPapperPrice;
        if(gameController.wormCount < blackPapperPrice)
        {
            blackPapperPriceText.color = Color.red;
        }
        else
        {
            blackPapperPriceText.color = Color.white;
        }
    }

    public void UpdateBoosterPrice()
    {
        boosterPriceText.text = "Price: " + boosterPrice;
        if(gameController.wormCount < boosterPrice)
        {
            boosterPriceText.color = Color.red;
        }
        else
        {
            boosterPriceText.color = Color.white;
        }
    }

    public void UpdateMagnetPrice()
    {
        magnetPriceText.text = "Price: " + magnetPrice;
        if(gameController.wormCount < magnetPrice)
        {
            magnetPriceText.color = Color.red;
        }
        else
        {
            magnetPriceText.color = Color.white;
        }
    }

    private void OnEnable()
    {
        UpdateBlackPapperPrice();
        UpdateBoosterPrice();
        UpdateMagnetPrice();

        blackPapperLevelText.text = "Level: " + blackPapperLevel;
        boosterLevelText.text = "Level: " + boosterLevel;
        magnetLevelText.text = "Level: " + magnetLevel;
    }
    
}
