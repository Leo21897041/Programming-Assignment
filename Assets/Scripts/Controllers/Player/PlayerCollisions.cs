using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject destroyParticles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroyed(collision);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroyed(collision);
        }

        if (collision.CompareTag("Power Up"))
        {
            Destroy(collision.gameObject);

            GetComponent<PlayerManager>().ActivatePowerUp();
        }
    }

    private void Destroyed(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

        Instantiate(destroyParticles, collision.transform.position, Quaternion.identity);
        Instantiate(destroyParticles, transform.position, Quaternion.identity);
    }
}
