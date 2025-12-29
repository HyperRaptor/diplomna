using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public List<GameObject> Units = new List<GameObject>();
    public List<GameObject> Guns = new List<GameObject>();
    void Awake() => Instance = this;
}
