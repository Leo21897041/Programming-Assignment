using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    
    public float spawnInterval = 5f;
    public float progress;

    public int spawnRate = 9;
    public float padding;

    private void Update()
    {
        progress += Time.deltaTime;

        if(progress >= spawnInterval)
        {
            SpawnPowerUp();

            progress = 0f;
        }
    }

    private int RandomNumber()
    {
        int randomNumber = Random.Range(0, spawnRate);

        return randomNumber;
    }
    private void SpawnPowerUp()
    {
        if (RandomNumber() == 0)
        {
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0 + padding, Screen.width - padding), Random.Range(0 + padding, Screen.height - padding), 0));
            randomPosition.z = 0f;
            
            Instantiate(powerUpPrefab, randomPosition, Quaternion.identity);
        }
    }
}
