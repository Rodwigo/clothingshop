using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text coins;
    public GameObject pauseMenu;

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
    void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
