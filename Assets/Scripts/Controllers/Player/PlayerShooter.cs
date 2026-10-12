using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject missilePrefab;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SpawnMissile();
        }
    }
    public void SpawnMissile()
    {
        Instantiate(missilePrefab, transform.position, transform.rotation);
    }
}
