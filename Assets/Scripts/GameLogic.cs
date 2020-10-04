using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private AudioLogic audioLogic;
    private int allCoins;
    private int coinsLeft;

    public Text coinText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        audioLogic = GetComponent<AudioLogic>();
        allCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        winText.enabled = false;
        UpdateText();
        print(allCoins);
    }

    public void UpdateText()
    {
        coinsLeft = GameObject.FindGameObjectsWithTag("Coin").Length - 1;
        print("point");

        coinText.text = $"Points: {allCoins - coinsLeft}/{allCoins}";

        if (allCoins - coinsLeft <= 0) Won();
    }

    private void Won()
    {
        audioLogic.PlayCoinSound();
        winText.enabled = true;
        Time.timeScale = 0.05f;
    }

}
