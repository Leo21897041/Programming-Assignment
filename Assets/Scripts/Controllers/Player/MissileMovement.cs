using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }
}
