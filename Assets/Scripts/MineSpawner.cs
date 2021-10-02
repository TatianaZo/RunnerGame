using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MineSpawner : MonoBehaviour
{
    
    private int mineIntensity;
    public GameObject mine;
    public RoadSpawner road;
    

    // Start is called before the first frame update
    void Start()
    {
        mineIntensity = PlayerPrefs.GetInt("MineNum");
        SpawnMines();
    }

    private void SpawnMines()
    {
        for(int i =0; i < mineIntensity; i++)
        {
            Instantiate(mine, new Vector3(Random.Range(-3.5f,3.5f), 0, Random.Range (10, road.roadLength * 5)),Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
