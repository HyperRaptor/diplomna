using UnityEngine;

public class WinCon : MonoBehaviour
{
    //Script that manages the player's victory
    public GameObject gameWin;
    public float endTime;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= endTime)
        {
            gameWin.SetActive(true);
            gameWin.GetComponent<GameEnd>().SetText("You have won!");
        }
    }
}
