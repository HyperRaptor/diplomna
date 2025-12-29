using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float setupTimer;
    private float interval;
    private float timer;
    void Start()
    {
        interval = setupTimer;
        timer = setupTimer;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            UnitManager.Instance.Units.Add(Instantiate(objectToSpawn, transform.position, Quaternion.identity,transform));
            timer = 0;
        }
    }
}
