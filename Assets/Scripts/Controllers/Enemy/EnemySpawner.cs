using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemySpawned;

    public float progress;
    public float duration;

    public float minSpawnRate;
    public float maxSpawnRate;
    public bool isGameOver;

    private void Start()
    {
        isGameOver = false;

        SpawnEnemy();

        ChangeSpawnRate();
    }

    private void Update()
    {
        if (isGameOver) { return; }        
        else
        {
            if (enemySpawned == null)
            {
                progress += Time.deltaTime;
        
                if (progress >= duration)
                {
                    SpawnEnemy();

                    ChangeSpawnRate();

                    progress = 0f;
                }
            }
        }
    }

    private void ChangeSpawnRate()
    {
        duration = Random.Range(minSpawnRate, maxSpawnRate);
    }

    private void SpawnEnemy()
    {
        if (enemySpawned == null)
        {
            enemySpawned = Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
