using UnityEngine;
public class AttackSpeedButton : EconButton
{
    public float speed;
    public GameObject gunPrefab;
    protected override void Execute(){
        base.Execute();
        foreach(GameObject gun in UnitManager.Instance.Guns){
            gun.GetComponent<Blaster>().AttackSpeedUpgrade(speed);
        }
        gunPrefab.GetComponent<Blaster>().setupTimer -= speed;
    }
}
