using UnityEngine;

public class PowerUpCollisions : MonoBehaviour
{
    public GameObject destroyParticles;
    public float padding;

    private void Update()
    {
        Despawner();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroyed(collision);
        }
        if(collision.CompareTag("Enemy"))
        {
            Destroyed(collision);
        }
    }

    private void Destroyed(Collider2D collision)
    {
        Destroy(collision.gameObject);

        Instantiate(destroyParticles, collision.transform.position, Quaternion.identity);        
    }

    private void Despawner()
    {
        float leftDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0 - (padding * 2), 0, 0)).x;
        float rightDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + (padding * 2), 0, 0)).x;
        float bottomDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0 - (padding * 2), 0)).y;
        float topDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + (padding * 2), 0)).y;

        if (transform.position.x < leftDespawnBoundary ||
            transform.position.x > rightDespawnBoundary ||
            transform.position.y < bottomDespawnBoundary ||
            transform.position.y > topDespawnBoundary)
        {
            Destroy(gameObject);
        }
    }
}
