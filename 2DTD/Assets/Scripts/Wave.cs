using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public WaveEnemies enemyDistribution;
    private float waveDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveDuration += Time.deltaTime;
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        foreach (WaveEnemy waveEnemy in enemyDistribution.WaveEnemies)
        {
            if (!waveEnemy.done && waveDuration >= waveEnemy.delay)
            {
                if (waveEnemy.AttemptSpawn())
                {
                    Instantiate(waveEnemy.enemy, transform);
                }
            }
        }
    }
}
