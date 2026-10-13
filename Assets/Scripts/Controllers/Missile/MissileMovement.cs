using UnityEngine;
using static UnityEngine.UI.ScrollRect;

public class MissileMovement : MonoBehaviour
{
    public float moveSpeed;
    public float padding = 25f;

    void Update()
    {
        Despawner();

        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }

    private void Despawner()
    {
        float leftDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0 - padding, 0, 0)).x;
        float rightDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + padding, 0, 0)).x;

        float bottomDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0 - padding, 0)).y;
        float topDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + padding, 0)).y;

        if (transform.position.x < leftDespawnBoundary||
            transform.position.x > rightDespawnBoundary||
            transform.position.y < bottomDespawnBoundary ||
            transform.position.y > topDespawnBoundary)
        {
            Destroy(gameObject);
        }
    }
}
