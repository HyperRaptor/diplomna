using UnityEngine;

public class Ammo_hit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            GetComponent<EnemyStats>().health -= 0.01f;
            Destroy(collision.gameObject);
            if(GetComponent<EnemyStats>().health <= 0)
            {
                UnitManager.Instance.Units.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
