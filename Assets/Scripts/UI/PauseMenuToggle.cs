using UnityEngine;

public class PauseMenuToggle : MenuToggle
{
    public override void Toggle()
    {
        base.Toggle();
        Time.timeScale = !isActive ? 0f : 1f;
    }
}
