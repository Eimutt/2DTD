using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericWaveEnemy<T>
{
    public T enemy;
    public int amount;
    public float interval;
    public bool done;
    public float delay;
    private int count;
    private float timer; 
    public bool AttemptSpawn()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            count++;
            if (count == amount)
                done = true;
            timer = 0;
            return true;
        }
        return false;
    }
}

public abstract class GenericWaveEnemies<T, U> where T : GenericWaveEnemy<U>
{
    [SerializeField]
    public List<T> WaveEnemies;
}

[System.Serializable]
public class WaveEnemy : GenericWaveEnemy<GameObject>
{
    
}

[System.Serializable]
public class WaveEnemies : GenericWaveEnemies<WaveEnemy, GameObject> { }