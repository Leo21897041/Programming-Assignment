using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MissileCollisions : MonoBehaviour
{
    public GameObject destroyParticles;
    public PlayerManager playerManager;
    public LevelManager levelManager;

    private void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroyed(collision);

            playerManager.numberOfAsteroidsDestroyed++;

            levelManager.numberOfAsteroidsShot++;
            levelManager.score += 5;
        }

        if (collision.CompareTag("Enemy") && this.gameObject.CompareTag("Player Missile"))
        {
            Destroyed(collision);

            levelManager.numberOfEnemiesShot++;
            levelManager.score += 75;
        }

        if (collision.CompareTag("Player") && this.gameObject.CompareTag("Enemy Missile"))
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
