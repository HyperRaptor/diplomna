using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public TMP_Text textToChange;
    void Start()
    {
        Time.timeScale = 0;
    }

    public void SetText(string text)
    {
        textToChange.text = text;
    }

}
