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
        UpdateText(true);
        print(allCoins);
    }

    public void UpdateText(bool first = false)
    {
        coinsLeft = GameObject.FindGameObjectsWithTag("Coin").Length - 1;
        print("point");

        
        if (first) coinText.text = $"Points: 0/{allCoins}";
        else coinText.text = $"Points: {allCoins - coinsLeft}/{allCoins}";

        if (allCoins - coinsLeft == allCoins) Won();
    }

    private void Won()
    {
        audioLogic.PlayCoinSound();
        winText.enabled = true;
        Time.timeScale = 0.05f;
    }

}
