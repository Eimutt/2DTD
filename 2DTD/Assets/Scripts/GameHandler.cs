using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private int wave;
    public int lives;
    public int money;


    public EnemySpawner EnemySpawner;
    public UiHandler UIHandler;


    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        UIHandler.InitUi(money, lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        lives -= 0;

        UIHandler.UpdateLivesAmount(lives);

        if (lives <= 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        //U losee 
    }

    public void StartNextWave()
    {
        EnemySpawner.SpawnNextWave(this.wave);

        wave++;
        UIHandler.UpdateWaveNumber(wave);
    }

    public void SpendMoney(int amount)
    {
        money += amount;
        UIHandler.UpdateMoneyAmount(money);
    }

    public void EarnMoney(int amount)
    {
        money += amount;
        UIHandler.UpdateMoneyAmount(money);
    }

}
