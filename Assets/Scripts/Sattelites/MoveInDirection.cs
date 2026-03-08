using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    //Script that dictates the movement of the blaster's bullets
    Vector3 direction;
    public float speed = 5;
    public void SetDirection(Vector3 dir)
    {
        if (dir.sqrMagnitude < 0.0001f)
        {
            dir = Vector3.right;
        }

        direction = dir.normalized;
    }

    private void AlignWithDirection(Vector3 toDirection)
    {
        float temp = Mathf.Atan2(toDirection.y, toDirection.x) * Mathf.Rad2Deg - 0;
        transform.rotation = Quaternion.Euler(0, 0, temp);
    }


    void Update()
    {
        AlignWithDirection(direction);
        transform.position += direction * (speed * Time.deltaTime);
    }
}
