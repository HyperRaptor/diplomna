using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //Script that manages units and sattelites
    public static UnitManager Instance;

    public List<GameObject> Units = new List<GameObject>();
    public List<GameObject> Sattelites = new List<GameObject>();
    bool pressed = false;
    public int normalSpeed, fastSpeed;
    void Awake() => Instance = this;
    public void ChangeState(){
        pressed = !pressed;
    }

    void Update()
    {
        if(Instance.Sattelites.Count > 0){
            if(pressed){
                foreach(GameObject gun in Instance.Sattelites){
                    gun.GetComponent<SpiralMovement>().speed = fastSpeed;
                }
            }
            else{
                foreach(GameObject gun in Instance.Sattelites){
                    gun.GetComponent<SpiralMovement>().speed = normalSpeed;
                }
            }
        }
    }
}
