using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public Vector3 randomPosition;
    public float moveProgress;
    public float moveDuration;

    void Start()
    {
        randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0));
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector3 direction = (randomPosition - transform.position).normalized;

        transform.position += moveSpeed * direction * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, randomPosition);

        if (distance <= arrivalDistance)
        {
            randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0));
        }
    }
}
