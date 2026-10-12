using UnityEngine;

public class MissileCollisions : MonoBehaviour
{
    public GameObject destroyParticles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Instantiate(destroyParticles, collision.transform.position, Quaternion.identity);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Instantiate(destroyParticles, collision.transform.position, Quaternion.identity);
        }
    }
}
