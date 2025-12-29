using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    //private const float moveAmountX = -520f;
    private const float moveAmountX = -380f;
    private RectTransform targetPanel;
    private bool hidden = false;

    public void Toggle()
    {
        Vector2 anchored = GetComponent<RectTransform>().anchoredPosition;
        if(hidden){
            anchored.x -= moveAmountX;
            hidden = false;
        } 
        else{
            anchored.x += moveAmountX;
            hidden = true;
        } 
        GetComponent<RectTransform>().anchoredPosition = anchored;
    }
}
