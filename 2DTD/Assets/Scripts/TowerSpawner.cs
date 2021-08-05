using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject ramp;
    public GameObject launchTower;

    public GameObject selectedTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTower = ramp;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTower = launchTower;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedTower != null)
            {
                Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPos.z = 0;
                Instantiate(selectedTower, spawnPos, Quaternion.Euler(0, 0, -45));
            }
        }
    }
}
