using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnNextWave(int wave)
    {
        this.transform.GetChild(wave).gameObject.SetActive(true);
    }
}
