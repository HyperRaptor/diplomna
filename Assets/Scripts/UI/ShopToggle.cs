using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    //Script that moves the shop of and on screen
    private float moveAmountX;
    private RectTransform targetPanel;
    private bool hidden = false;

    void Start()
    {
        moveAmountX = GetComponent<RectTransform>().anchoredPosition.x;
    }
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
