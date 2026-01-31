using UnityEngine;

public abstract class ShopButton : MonoBehaviour
{
    //Script that manages the deduction of money when a button in the shop is pressed
    public int cost;
    private GameObject global;
    protected virtual void Start()
    {
        global = GameObject.Find("Global");
    }
    public virtual void ButtonClick()
    {
        if(global.GetComponent<Econ>().Deduct(cost))
        {
            Execute();
        }
    }
    protected abstract void Execute();
}