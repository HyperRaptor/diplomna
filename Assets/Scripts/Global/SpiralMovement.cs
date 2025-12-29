using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    GameObject Centre;
    public int angle;
    public int speed = 1;
    void Start()
    {
        Centre = GameObject.Find("Black Hole");
    }
    void Update()
    {
        Vector3 direction = Centre.transform.position - transform.position;
        direction = Quaternion.Euler(0, 0, angle) * direction;
        if(angle == 90) AlignWithDirection(direction);
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void AlignWithDirection(Vector3 direction)
    {
        float temp = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, temp);
    }
}
