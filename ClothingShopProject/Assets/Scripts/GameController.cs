using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text coins;
    public GameObject pauseMenu;

    [Header("Clothes")]
    public Button socialBtn;
    public Button casualBtn;
    public Button exoticBtn;

    public Button socialBtnNPC1;
    public Button casualBtnNPC1;
    public Button exoticBtnNPC1;

    public Button socialBtnNPC2;
    public Button casualBtnNPC2;
    public Button exoticBtnNPC2;

    public Button socialBtnNPC3;
    public Button casualBtnNPC3;
    public Button exoticBtnNPC3;

    [Header("Skins")]
    public Animator playerAnim;
    public AnimatorOverrideController socialClt;
    public AnimatorOverrideController casualClt;
    public AnimatorOverrideController exoticClt;
    public AnimatorOverrideController defaulClt;
    bool usingSocial = false;
    bool usingCasual = false;
    bool usingExotic = false;

    void Start()
    {
        AddCoins(50);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToScene(0);
        }
    }

    void AddCoins(int quant)
    {
        var coinsInt = int.Parse(coins.text);
        coinsInt += quant;
        coins.text = coinsInt.ToString();
    }

    bool RemoveCoins(int quant)
    {
        var coinsInt = int.Parse(coins.text);
        if(coinsInt < quant)
        {
            Debug.Log("Not enough Money!");
            return false;
        }
        coinsInt -= quant;
        coins.text = coinsInt.ToString();
        return true;
    }
    void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void BuyClothes(string type)
    {
        switch (type)
        {
            case "social":
                if (RemoveCoins(40))
                {
                    Debug.Log("comprado!");
                    socialBtn.interactable = true;
                    socialBtnNPC1.interactable = true;
                    socialBtnNPC2.interactable = true;
                    socialBtnNPC3.interactable = true;
                }
                break;
            case "casual":
                if (RemoveCoins(30))
                {
                    Debug.Log("comprado!");
                    casualBtn.interactable = true;
                    casualBtnNPC1.interactable = true;
                    casualBtnNPC2.interactable = true;
                    casualBtnNPC3.interactable = true;
                }
                break;
            case "exotic":
                if (RemoveCoins(60))
                {
                    Debug.Log("comprado!");
                    exoticBtn.interactable = true;
                    exoticBtnNPC1.interactable = true;
                    exoticBtnNPC2.interactable = true;
                    exoticBtnNPC3.interactable = true;
                }
                break;
            default:
                Debug.LogError("Should not reach Default State!");
                break;
        }
    }

    public void SellClothes(string type, int price)
    {
        switch (type)
        {
            case "social":
                AddCoins(price);
                socialBtn.interactable = false;
                socialBtnNPC1.interactable = false;
                socialBtnNPC2.interactable = false;
                socialBtnNPC3.interactable = false;       
                break;
            case "casual":
                AddCoins(price);
                casualBtn.interactable = false;
                casualBtnNPC1.interactable = false;
                casualBtnNPC2.interactable = false;
                casualBtnNPC3.interactable = false;
                break;
            case "exotic":
                AddCoins(price);
                exoticBtn.interactable = false;
                exoticBtnNPC1.interactable = false;
                exoticBtnNPC2.interactable = false;
                exoticBtnNPC3.interactable = false;
                break;
            default:
                Debug.Log("Should not reach default state!");
                break;
        }
    }
     public void NPC1SocialSell()
    {
        SellClothes("social", 30);
        if (usingSocial)
        {
            DefaultSkin();
        }
    }
    public void NPC1CasualSell()
    {
        SellClothes("casual", 20);
        if (usingCasual)
        {
            DefaultSkin();
        }
    }
    public void NPC1ExoticSell()
    {
        SellClothes("exotic", 100);
        if (usingExotic)
        {
            DefaultSkin();
        }
    }
    public void NPC2SocialSell()
    {
        SellClothes("social", 50);
        if (usingSocial)
        {
            DefaultSkin();
        }
    }
    public void NPC2CasualSell()
    {
        SellClothes("casual", 40);
        if (usingCasual)
        {
            DefaultSkin();
        }
    }
    public void NPC2ExoticSell()
    {
        SellClothes("exotic", 10);
        if (usingExotic)
        {
            DefaultSkin();
        }
    }
    public void NPC3SocialSell()
    {
        SellClothes("social", 10);
        if (usingSocial)
        {
            DefaultSkin();
        }
    }
    public void NPC3CasualSell()
    {
        SellClothes("casual", 10);
        if (usingCasual)
        {
            DefaultSkin();
        }
    }
    public void NPC3ExoticSell()
    {
        SellClothes("exotic", 60);
        if (usingExotic)
        {
            DefaultSkin();
        }
    }

    public void CasualSkin()
    {
        playerAnim.runtimeAnimatorController = casualClt as RuntimeAnimatorController;
        usingSocial = false;
        usingCasual = true;
        usingExotic = false;
    }
    public void SocialSkin()
    {
        playerAnim.runtimeAnimatorController = socialClt as RuntimeAnimatorController;
        usingSocial = true;
        usingCasual = false;
        usingExotic = false;
    }
    public void ExoticSkin()
    {
        playerAnim.runtimeAnimatorController = exoticClt as RuntimeAnimatorController;
        usingSocial = false;
        usingCasual = false;
        usingExotic = true;
    }
    public void DefaultSkin()
    {
        playerAnim.runtimeAnimatorController = defaulClt as RuntimeAnimatorController;
        usingSocial = false;
        usingCasual = false;
        usingExotic = false;
    }
}
