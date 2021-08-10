using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    public GameObject Canvas;

    private Text waveNumber;
    private Text moneyAmount;
    private Text livesAmount;


    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        waveNumber = GameObject.Find("WaveNumber").GetComponent<Text>();
        moneyAmount = GameObject.Find("MoneyAmount").GetComponent<Text>();
        livesAmount = GameObject.Find("LivesAmount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWaveNumber(int wave)
    {
        waveNumber.text = "Wave: " + wave.ToString();
    }

    public void UpdateMoneyAmount(int money)
    {
        moneyAmount.text = "Money: " + money.ToString();
    }

    public void UpdateLivesAmount(int lives)
    {
        livesAmount.text = "Lives: " + lives.ToString();
    }

    public void InitUi(int money, int lives)
    {
        UpdateWaveNumber(1);
        UpdateMoneyAmount(money);
        UpdateLivesAmount(lives);
    }
}
