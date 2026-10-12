using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject missilePrefab;
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void SpawnMissile()
    {
        Instantiate(missilePrefab, transform.position, transform.rotation);
    }
}
