using UnityEngine;

public class OnCollisison : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Eatable"))
        {
            float objectHealth = collision.gameObject.GetComponent<EnemyStats>().health;
            transform.localScale += new Vector3(objectHealth, objectHealth, objectHealth);
            UnitManager.Instance.Units.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
