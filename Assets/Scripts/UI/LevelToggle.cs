using UnityEngine;

public class LevelToggle : MonoBehaviour
{
    protected bool isActive;
    public virtual void Toggle()
    {
        isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);
    }
}
