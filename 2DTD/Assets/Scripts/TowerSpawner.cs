using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject[] towers;

    public int selectedTower = -1;

    private bool outLineSpawned;
    private GameObject Outline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyBoardInput();

        if (outLineSpawned)
        {
            MoveOutLine();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedTower != -1)
            {
                AttemptTowerSpawn();
            }
        }
    }

    void SpawnOutline()
    {
        if (outLineSpawned)
        {
            Destroy(Outline);
        }
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPos.z = 0;
        Outline = Instantiate(towers[selectedTower], spawnPos, Quaternion.Euler(0, 0, 0));
        Outline.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        Outline.GetComponent<Collider2D>().enabled = false;

        outLineSpawned = true;

    }

    void MoveOutLine()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;
        float newX = Mathf.Floor(mousePos.x) + 0.5f;

        float newY = Mathf.Floor(mousePos.y) + 0.5f;
        mousePos.x = newX;
        mousePos.y = newY;

        Outline.transform.position = mousePos;

    }

    void DeslectTower()
    {
        Destroy(Outline);
        selectedTower = -1;
        outLineSpawned = false;
    }

    void AttemptTowerSpawn()
    {
        //do check if can spawn

        Instantiate(towers[selectedTower], Outline.transform.position, Quaternion.Euler(0, 0, 0));
        DeslectTower();
    }

    void CheckKeyBoardInput()
    {

        if (Input.GetKeyDown(KeyCode.Escape)){
            DeslectTower();
        }

        else if (Input.inputString != "")
        {

            int number;
            bool is_a_number = Int32.TryParse(Input.inputString, out number);
            if (is_a_number && number >= 0 && number <= towers.Length)
            {
                selectedTower = number - 1;
                SpawnOutline();
            }
        }
    }
}
