using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class EconButton : ShopButton
{
    private int current = 0;
    public int max = 1;
    private TMP_Text count;
    protected override void Start()
    {
        base.Start();
        count = gameObject.transform.parent.Find("Count").gameObject.GetComponent<TMP_Text>();
        count.text = current.ToString() + "/" + max.ToString();
    }
    public override void ButtonClick()
    {
        if(current < max)
        {
            base.ButtonClick();
        }
    }
    protected override void Execute()
    {
        current++;
        count.text = current.ToString() + "/" + max.ToString();
    }
}