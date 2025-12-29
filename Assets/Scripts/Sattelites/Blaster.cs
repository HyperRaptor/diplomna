using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float setupTimer;
    float interval;
    float timer;
    void Start()
    {
        interval = setupTimer;
        timer = setupTimer;
    }
    public void AttackSpeedUpgrade(float speed)
    {
        interval -= speed;
    }
    void Update()
    {
        if(UnitManager.Instance.Units.Count > 0)
        {
            timer += Time.deltaTime;
            if(timer >= interval)
            {
                GameObject min = UnitManager.Instance.Units[0];
                foreach(GameObject unit in UnitManager.Instance.Units)
                {
                    if(Vector3.Distance(min.transform.position, transform.position) > Vector3.Distance(unit.transform.position, transform.position))
                    {
                        min = unit;
                    }
                }
                GameObject bullet = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                Vector3 direction = (min.transform.position - transform.position);
                bullet.GetComponent<MoveInDirection>().SetDirection(direction);
                timer = 0;
            }
        }
    }
}
