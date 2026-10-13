using UnityEngine;

public class MissileCollisions : MonoBehaviour
{
    public GameObject destroyParticles;
    public PlayerManager playerManager;

    private void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroyed(collision);

            playerManager.numberOfAsteroidsDestroyed++;
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroyed(collision);
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
