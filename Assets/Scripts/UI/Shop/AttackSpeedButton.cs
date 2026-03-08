using UnityEngine;
public class AttackSpeedButton : EconButton
{
    //Script for a shop button that increases the attack speed of satellites
    public float speed;
    public GameObject gunPrefab;
    protected override void Execute()
    {
        base.Execute();
        foreach (GameObject gun in UnitManager.Instance.Sattelites)
        {
            gun.GetComponent<Blaster>().AttackSpeedUpgrade(speed);
        }
        gunPrefab.GetComponent<Blaster>().setupTimer -= speed;
    }
}
