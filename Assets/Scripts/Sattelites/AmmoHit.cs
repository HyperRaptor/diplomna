using UnityEngine;

public class AmmoHit : MonoBehaviour
{
    //Script that manages the logic of an enemy taking damage
    public int damage;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            GetComponent<EnemyStats>().health -= damage;
            Destroy(collision.gameObject);
            if (GetComponent<EnemyStats>().health <= 0)
            {
                UnitManager.Instance.Units.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
