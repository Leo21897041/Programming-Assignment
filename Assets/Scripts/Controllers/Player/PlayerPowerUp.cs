using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float radius;

    public void SpawnShields()
    {
        for (int i = 0; i < 4; i++)
        {
            float angle = (i * 90f);
            float angleInRadians = angle * Mathf.Deg2Rad;

            Vector3 shieldPosition = new Vector3(Mathf.Cos(angleInRadians) * radius, Mathf.Sin(angleInRadians) * radius, 0f);
            
            GameObject shieldPowerUpObj = Instantiate(shieldPrefab, transform.position + shieldPosition, Quaternion.identity);
            PowerUpMovement powerUpMovement = shieldPowerUpObj.GetComponent<PowerUpMovement>();
            
            powerUpMovement.playerTransform = this.transform;
            powerUpMovement.radius = radius;
            powerUpMovement.angle = angle;
        }
    }
}
