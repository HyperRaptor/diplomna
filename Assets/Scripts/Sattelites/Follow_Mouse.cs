using UnityEngine;

public class Follow_Mouse : MonoBehaviour
{
    float timer = 0;
    float interval = 0.1f;

    Vector3 worldPosition;

    public Follow_Mouse thisScript;
    public SpiralMovement moveScript;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 5;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPosition;
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            if (Input.GetMouseButtonDown(0))
            {
                moveScript.enabled = true;
                thisScript.enabled = false;
            }
        }
    }
}
