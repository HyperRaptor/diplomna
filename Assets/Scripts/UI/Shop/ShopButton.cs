using UnityEngine;

public abstract class ShopButton : MonoBehaviour
{
    public int cost;
    private GameObject econ;
    protected virtual void Start()
    {
        econ = GameObject.Find("Global");
    }
    public virtual void ButtonClick()
    {
        if(econ.GetComponent<Econ>().Deduct(cost))
        {
            Execute();
        }
    }
    protected abstract void Execute();
}