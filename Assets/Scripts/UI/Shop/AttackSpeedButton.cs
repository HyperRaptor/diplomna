using UnityEngine;
public class AttackSpeedButton : EconButton
{
    public float speed;
    /*protected override void Execute(){
        base.Execute();
        foreach(GameObject gun in Unit_manager.Instance.Guns){
            gun.GetComponent<Blaster>().AttackSpeedUpgrade(speed);
        }
    }*/
}
