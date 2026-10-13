using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float radius;
    public float speed;
    public float angle;

    public Transform playerTransform;

    public float acceleration;
    public float maxSpeed;

    private Vector3 position;

    public bool isLaunched;
    private Vector3 direction;

    void Update()
    {
        float angleInRadians = angle * Mathf.Deg2Rad;
        
        Vector3 circlePosition = new Vector3(Mathf.Cos(angleInRadians) * radius, Mathf.Sin(angleInRadians) * radius, 0f);
            
        speed += acceleration * Time.deltaTime;
        angle += Time.deltaTime * speed;
        
        if (!isLaunched)
        {                        
            position = playerTransform.position + circlePosition;
        
            if (speed > maxSpeed * 1.5f)
            {
                isLaunched = true;

                direction = circlePosition.normalized;
            }
        }

        else
        {
            position += direction * (speed / 10)* Time.deltaTime;
        }

        transform.position = position;
    }
}
