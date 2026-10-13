using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Position")]
    public Vector3 randomPosition;
    public Vector3 destinationPosition;
    public Vector3 position;
    public string movementType;
    public Transform playerTransform;

    [Header("Movement")]
    //public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public float moveProgress;
    public float moveDuration;
    public float padding;
    public float minDistanceToPlayer = 1f;

    [Header("Acceleration, Decceleration, & Velocity")]
    public Vector3 velocity;
    public float acceleration;
    public float accelerationTime;
    public float decceleration;
    public float deccelerationTime;
    public float maxSpeed;
    
    [Header("State")]
    public bool isGameOver;

    [Header("Scripts")]
    public AsteroidSpawner asteroidSpawner;

    void Start()
    {       
        RandomPosition();

        playerTransform = FindFirstObjectByType<PlayerMovement>().transform;

        acceleration = maxSpeed / accelerationTime;
        decceleration = maxSpeed / deccelerationTime;

        velocity = (destinationPosition - transform.position).normalized * acceleration;
    }

    void Update()
    {
        if (isGameOver)
        {
            Deccelerate();
        }
        else
        {
            Movement();
            Despawner();
        }

        transform.position += velocity * Time.deltaTime;
    }

    public void Movement()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < minDistanceToPlayer)
            {
                MoveTowardsPlayer();
            }
        }

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);
    }
    public void Deccelerate()
    {
        velocity -= velocity.normalized * decceleration * Time.deltaTime;
    }

    private void MoveTowardsPlayer()
    {
        destinationPosition = playerTransform.position;

        Vector3 direction = (destinationPosition - transform.position).normalized;
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
            asteroidSpawner.spawnedAsteroids.Remove(this);
            Destroy(gameObject);
        }
    }
}
