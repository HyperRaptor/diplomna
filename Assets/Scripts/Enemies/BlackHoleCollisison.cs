using UnityEngine;

public class BlackHoleCollisison : MonoBehaviour
{
    public float sizeIncrease;
    public float sizeThreshold;
    public GameObject gameOver;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Eatable"))
        {
            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
            UnitManager.Instance.Units.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (transform.localScale.x > sizeThreshold)
        {
            gameOver.SetActive(true);
        }
    }
}
