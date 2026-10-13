using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.ScrollRect;

public class EnemyMovement : MonoBehaviour
{
    public float rotationSpeed;
    public Transform playerTransform;

    public Vector3 velocity;
    public float acceleration;
    public float accelerationTime;
    public float maxSpeed;

    public bool isPlayerSpotted;

    public Vector3 randomPosition;
    public Vector3 destinationPosition;
    public Vector3 position;
    public string movementType;
    public float padding;
    private void Start()
    {
        isPlayerSpotted = false;
        acceleration = maxSpeed / accelerationTime;

        RandomPosition();
        playerTransform = FindFirstObjectByType<PlayerMovement>().transform;

        velocity = (destinationPosition - transform.position).normalized * acceleration;
    }
    void Update()
    {
        SpotPlayer();
        Movement();
        StayWithinScreenBounds();
        Despawner();
    }

    private void Movement()
    {
        if (isPlayerSpotted)
        {
            MoveTowardsPlayer();
        }

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);

        transform.position += velocity * Time.deltaTime;
    }

    private void MoveTowardsPlayer()
    {
        destinationPosition = playerTransform.position;

        Vector3 direction = (destinationPosition - transform.position).normalized;

        velocity += direction * acceleration * Time.deltaTime;
    }
    private void SpotPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        float dotProduct = Vector3.Dot(transform.up, direction);

        if (dotProduct >= 0)
        {
            isPlayerSpotted = true;

            float angleOne = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;
            float angleTwo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float deltaAngle = Mathf.DeltaAngle(angleOne, angleTwo);

            if (dotProduct < 0.99f)
            {
                if (Mathf.Sign(deltaAngle) == 1)
                {
                    transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                }
                else if (Mathf.Sign(deltaAngle) == -1)
                {
                    transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
    private void StayWithinScreenBounds()
    {
        float screenLeft = 0;
        float screenRight = Screen.width;
        float screenBottom = 0;
        float screenTop = Screen.height;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < screenLeft)
        {
            screenPosition.x = screenLeft;

            velocity.x = 0;
        }
        else if (screenPosition.x > screenRight)
        {
            screenPosition.x = screenRight;

            velocity.x = 0;
        }

        if (screenPosition.y < screenBottom)
        {
            screenPosition.y = screenBottom;

            velocity.y = 0;
        }
        else if (screenPosition.y > screenTop)
        {
            screenPosition.y = screenTop;

            velocity.y = 0;
        }

        transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
    }
    private void RandomPosition()
    {
        switch (movementType)
        {
            case "Left": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(0 - (padding * 3), Random.Range(0, Screen.height), 0)); break;
            case "Right": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + (padding * 3), Random.Range(0, Screen.height), 0)); break;
            case "Up": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height + (padding * 3), 0)); break;
            case "Down": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0 - (padding * 3), 0)); break;
        }

        randomPosition.z = 0f;

        destinationPosition = randomPosition;
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
