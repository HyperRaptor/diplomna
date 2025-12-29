using UnityEngine;

namespace Shop
{
    public class WeaponButton : ShopButton
    {
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
            UnitManager.Instance.Guns.Add(Instantiate(objectToSpawn));
            shop.GetComponent<ShopToggle>().Toggle();
            shopToggle.GetComponent<ToggleArrow>().Toggle();
        }
    }
}