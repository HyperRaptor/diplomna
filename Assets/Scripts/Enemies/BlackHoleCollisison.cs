using UnityEngine;

public class BlackHoleCollisison : MonoBehaviour
{
    //Script for controlling the size increase of the black hole and the deletion of entities colliding with it
    public float sizeIncrease;
    public float sizeThreshold;
    public GameObject gameOver;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Consumable"))
        {
            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
            UnitManager.Instance.Units.Remove(collision.gameObject);
        }
        else if (!collision.gameObject.CompareTag("Ammo"))
        {
            UnitManager.Instance.Sattelites.Remove(collision.gameObject);
        }
        Destroy(collision.gameObject);
    }

    private void Update()
    {
        if (transform.localScale.x > sizeThreshold)
        {
            gameOver.SetActive(true);
        }
    }
}
