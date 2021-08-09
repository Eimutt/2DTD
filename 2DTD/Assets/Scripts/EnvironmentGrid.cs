using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnvironmentEnum
{
    Empty = 0,
    Ground = 1,
    MapObjective = 2,
    Tower = 3
}

public class EnvironmentGrid : MonoBehaviour
{
    public int xSize;
    public int ySize;
    private EnvironmentEnum[,] Grid;
    // Start is called before the first frame update
    void Start()
    {
        Grid = new EnvironmentEnum[xSize, ySize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
