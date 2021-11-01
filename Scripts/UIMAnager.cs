using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMAnager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText, _coinText, _AmmoText, coinStore;
    [SerializeField]
    private Text _HighScore;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _coinText.text = "Coin: " + 0;
        _AmmoText.text = "Ammo: " + 50;
        _HighScore.text = "High Score: " + Player._bestScore;
        coinStore.text = "Coin: " + Player.coin;
    }

    // Update is called once per frame
    void Update()
    {
        _HighScore.text = "High Score: " + Player._bestScore;
        coinStore.text = "Coin: " + Player.coin;
    }
    public void updateScore(int x)
    {
        _scoreText.text = "Score: " + x.ToString();
    }
    public void updateCoin(int x)
    {
        _coinText.text = "Coin: " + x.ToString();
    }
    public void updateAmmmo(int x)
    {
        _AmmoText.text = "Ammo: " + x.ToString();
    }
}
