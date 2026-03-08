using UnityEngine;
using TMPro;

public class ToggleArrow : MonoBehaviour
{
    private bool left = true;
    public void Toggle()
    {
        gameObject.GetComponent<TMP_Text>().text = left ? ">" : "<";
        left = !left;
    }
}
