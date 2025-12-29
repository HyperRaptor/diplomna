using UnityEngine;

public class MenuToggle : LevelToggle
{
    public override void Toggle()
    {
        base.Toggle();
        Time.timeScale = !isActive ? 0f : 1f;
    }
}
