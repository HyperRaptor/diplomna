using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public List<GameObject> Units = new List<GameObject>();
    public List<GameObject> Guns = new List<GameObject>();
    bool pressed = false;
    public int normalSpeed, fastSpeed;
    void Awake() => Instance = this;
    public void ChangeState(){
        pressed = !pressed;
    }

    void Update()
    {
        if(Instance.Guns.Count > 0){
            if(pressed){
                foreach(GameObject gun in Instance.Guns){
                    gun.GetComponent<SpiralMovement>().speed = fastSpeed;
                }
            }
            else{
                foreach(GameObject gun in Instance.Guns){
                    gun.GetComponent<SpiralMovement>().speed = normalSpeed;
                }
            }
        }
        //pressed = false;
    }
}
