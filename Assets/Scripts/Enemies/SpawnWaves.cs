using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float setupTimer;
    private float interval;
    private float timer;
    
    private Transform[] spawnPoints;
    private int spawnIndex = 0;
    
    void Start()
    {
        interval = setupTimer;
        timer = 0;
        
        spawnPoints = new Transform[4];
        spawnPoints[0] = GameObject.Find("SpawnerUp").transform;
        spawnPoints[1] = GameObject.Find("SpawnerDown").transform;
        spawnPoints[2] = GameObject.Find("SpawnerLeft").transform;
        spawnPoints[3] = GameObject.Find("SpawnerRight").transform;
    }
    void Update()
    {
        
        int[] spawnOrder = {0, 1, 2, 3};
        Shuffle(spawnOrder);
        
        timer += Time.deltaTime;
        
        if(timer >= interval)
        {
            Transform spawnPoint = spawnPoints[spawnOrder[spawnIndex]];
            UnitManager.Instance.Units.Add(Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation));
            
            spawnIndex = (spawnIndex + 1) % spawnOrder.Length;
            timer = 0;
        }
    }
    
    void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}