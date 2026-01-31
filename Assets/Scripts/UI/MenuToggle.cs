using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    protected bool isActive;
    public virtual void Toggle()
    {
        isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);
    }
}
