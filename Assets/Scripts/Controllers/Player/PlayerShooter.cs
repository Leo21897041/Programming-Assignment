using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject missilePrefab;

    public int numberOfMissiles;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SpawnMissile(numberOfMissiles);
        }
    }
    public void SpawnMissile(int _numberOfMissiles)
    {
        for(int i = 0; i < _numberOfMissiles; i++)
        {
            GameObject missileObj = Instantiate(missilePrefab, transform.position + SpawnOffset(_numberOfMissiles, i), transform.rotation);
        }        
    }

    public Vector3 SpawnOffset(int _numberOfMissiles, int _index)
    {
        if(_numberOfMissiles <= 1) 
        { 
            return Vector3.zero; 
        }

        float shipSize = GetComponent<BoxCollider2D>().size.x;
        
        float spacing = shipSize / (_numberOfMissiles - 1);

        float offsetAmount = (-shipSize / 2) + (_index * spacing);

        Vector3 offset = transform.right * offsetAmount;
        offset.z = 0f;

        return offset;
    }
}
