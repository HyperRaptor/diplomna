using UnityEngine;

public class PublicFundingButton : EconButton
{
    //Script for a shop button that increases the rate at which the player's money increases
    public int prod;
    private Econ econ;

    protected override void Start()
    {
        base.Start();
        econ = GameObject.Find("Global").GetComponent<Econ>();
    }

    protected override void Execute()
    {
        base.Execute();
        econ.econ += prod;
    }
}
