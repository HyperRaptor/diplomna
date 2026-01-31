using UnityEngine;

public class WeaponButton : ShopButton
{
    //Script for a shop button that creates a satellite
    public GameObject objectToSpawn;
    private GameObject shop;
    private GameObject shopToggle;
    protected override void Start()
    {
        base.Start();
        shop = GameObject.Find("Shop");
        shopToggle = GameObject.Find("ShopToggleName");
    }

    protected override void Execute()
    {
        PlacementManager.Instance.BeginPlacement(objectToSpawn);
        shop.GetComponent<ShopToggle>().Toggle(); 
        shopToggle.GetComponent<ToggleArrow>().Toggle(); 
    }
}