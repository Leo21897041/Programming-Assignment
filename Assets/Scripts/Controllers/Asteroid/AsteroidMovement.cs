using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Position")]
    public Vector3 randomPosition;
    public Vector3 destinationPosition;
    public Vector3 position;
    public string movementType;

    [Header("Movement")]
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public float moveProgress;
    public float moveDuration;

    void Start()
    {       
        RandomPosition();
    }

    void Update()
    {
        Movement();
        Despawner();
    }

    public void Movement()
    {        
        Vector3 direction = (destinationPosition - transform.position).normalized;

        transform.position += moveSpeed * direction * Time.deltaTime;
    }
    
    private void RandomPosition()
    {
        switch (movementType)
        {
            case "Left": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(0 - padding, Random.Range(0, Screen.height), 0)); break;
            case "Right": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + padding, Random.Range(0, Screen.height), 0)); break;
            case "Up": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height + padding, 0)); break;
            case "Down": randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0 - padding, 0)); break;
        }

        randomPosition.z = 0f;

        destinationPosition = randomPosition;
    }
    private void Despawner()
    {
        float leftDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0 - padding, 0, 0)).x;
        float rightDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + padding, 0, 0)).x;

        float bottomDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0 - padding, 0)).y;
        float topDespawnBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + padding, 0)).y;

        if (transform.position.x < leftDespawnBoundary && movementType == "Left"||
            transform.position.x > rightDespawnBoundary && movementType == "Right"||
            transform.position.y < bottomDespawnBoundary && movementType == "Down"||
            transform.position.y > topDespawnBoundary && movementType == "Up")
        {
            Destroy(gameObject);
        }
    }
}
