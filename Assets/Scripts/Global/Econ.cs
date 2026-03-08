using UnityEngine;
using TMPro;

public class Econ : MonoBehaviour
{
    //Script to manage the player's money and it's changes
    private TMP_Text display;
    public int money = 0;
    public int econ = 10;
    private float interval;
    private float timer;
    public float setupTimer;
    void Start()
    {
        Time.timeScale = 1;
        display = GameObject.Find("Money").GetComponent<TMP_Text>();
        display.text = money.ToString();
        interval = setupTimer;
        timer = setupTimer;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            MoneyChange(econ);
            timer = 0;
        }
    }

    private void MoneyChange(int value)
    {
        money += value;
        display.text = money.ToString();
    }
    public bool Deduct(int value)
    {
        if ((money - value) < 0) return false;
        MoneyChange(-value);
        return true;
    }
}
